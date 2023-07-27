using AutoMapper;
using BCrypt.Net;
using MediatR;
using Seafood.ARCHITECTURE.Constants;
using Seafood.ARCHITECTURE.Entities.Models;
using Seafood.CORE.MediatR.UserFuction.Model;
using Seafood.CORE.Repositories.UserRepo;
using Seafood.INFRASTRUCTURE.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.CORE.MediatR.UserFuction.AddUserHandler
{
    public record AddUserCommand(UserMediatModel UserMediatModel) : IRequest<UserMediatModel>;

    public class AddUserHandler : IRequestHandler<AddUserCommand, UserMediatModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ISeafoodDbContext _seafoodDbContext;

        public AddUserHandler(IMapper mapper, IUserRepository userRepository, ISeafoodDbContext seafoodDbContext)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _seafoodDbContext = seafoodDbContext;
        }

        public async Task<UserMediatModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = new User()
                {
                    Id = Guid.NewGuid(),
                    Username = request.UserMediatModel.Username,
                    DisplayName = request.UserMediatModel.Username,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.UserMediatModel.Password, ArchitectureContants.BCRYPT_SALT),
                    Salt = ArchitectureContants.BCRYPT_SALT,
                    IsAdminUser = request.UserMediatModel.Role.Contains("admin") ? true : false,
                    IsLocked = false,
                    Role = request.UserMediatModel.Role,
                    Sex = request.UserMediatModel.Sex,
                    Mobile = request.UserMediatModel.Mobile,
                };
                _seafoodDbContext.Users.Add(user);
                await _seafoodDbContext.SaveChangesAsync(cancellationToken);

                //await _userRepository.Add(user);
                return request.UserMediatModel;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

}
