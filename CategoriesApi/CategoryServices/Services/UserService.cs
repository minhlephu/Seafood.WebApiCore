using AutoMapper;
using BCrypt.Net;
using CategoryServices.Interfaces;
using Domains.DTOs;
using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryServices.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<User> GetUserToContext(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task DeleteUser(Guid id)
        {
            await _repository.DeleteById(id);
        }

        public async Task<bool> ExistsUserByEmail(string email)
        {
            return await _repository.ExistsByEmail(email);
        }

        public async Task<bool> ExistsUserById(Guid id)
        {
            return await (_repository.ExistsById(id));
        }

        public async Task<bool> ExistsUserByUsername(string username)
        {
            return await _repository.ExistsByUsername(username);
        }

        public async Task<UserResponse> GetUserById(Guid id)
        {
            var user = await _repository.GetById(id);
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            var user = await _repository.GetByUsername(request.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new Exception("Username or password is incorrect");
            }
            return _mapper.Map<SignInResponse>(user);
        }

        public async Task<SignUpResponse> SignUp(SignUpRequest request)
        {
            if(await _repository.ExistsByUsername(request.Username) || await _repository.ExistsByEmail(request.Email))
            {
                throw new Exception("Username or Email is already taken");
            }
            var user = _mapper.Map<User>(request);
            user.Id = Guid.NewGuid();
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Roles = Role.User.ToString();
            user.CreatedAt = DateTime.UtcNow;
            user.CreatedBy = "dev_local";

            var response = await _repository.Save(user);
            return _mapper.Map<SignUpResponse>(response);
        }
    }
}
