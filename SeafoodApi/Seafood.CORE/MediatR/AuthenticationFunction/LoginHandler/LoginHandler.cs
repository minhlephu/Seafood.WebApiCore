using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seafood.INFRASTRUCTURE.Base.Interfaces;
using AutoMapper;
using Seafood.ARCHITECTURE.Entities.Models;
using Seafood.INFRASTRUCTURE.Base.Models;
using System.Runtime.CompilerServices;
using Seafood.CORE.Repositories.UserRepo;
using Seafood.ARCHITECTURE.Constants;
using Microsoft.AspNetCore.Http;

namespace Seafood.CORE.MediatR.AuthenticationFunction.LoginHandler
{
    public record LoginCommand(LoginMediatModel LoginMediatModel) : IRequest<LoginMediatResultModel>;

    public class LoginHandler : IRequestHandler<LoginCommand, LoginMediatResultModel>
    {
        private readonly ISeafoodDbContext _context;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly IUserRepository _userRepository;

        public LoginHandler(ISeafoodDbContext context, IMapper mapper, IJwtService jwtService, IUserRepository userRepository)
        {
            _context = context;
            _mapper = mapper;
            _jwtService = jwtService;
            _userRepository = userRepository;
        }

        public async Task<LoginMediatResultModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //var user = await _context.Users.SingleOrDefaultAsync(i => i.Username == request.LoginMediatModel.Username);
            //if (user != null)
            //{
            //    var salt = user.Username;
            //    var requestPassHash = BCrypt.Net.BCrypt.HashPassword(request.LoginMediatModel.Password, salt);

            //    if (user.PasswordHash == requestPassHash)
            //    {
            //        return _mapper.Map<User, LoginMediatResultModel>(user);
            //    }
            //}
            //return null;

            //var user = _context.Users.SingleOrDefault(i => i.Username == request.LoginMediatModel.Username);

            var user = await _userRepository.Login(request.LoginMediatModel.Username, request.LoginMediatModel.Password);

            if (user != null)
            {
                var loginMediatResultModel = _mapper.Map<User, LoginMediatResultModel>(user);
                loginMediatResultModel.AccessToken = _jwtService.CreateToken(_mapper.Map<LoginMediatResultModel, JwtModel>(loginMediatResultModel));


                return loginMediatResultModel;
            }
            else
            {
                return null;
            }
        }
    }

    public class LoginMediatModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginMediatResultModel
    {
        public string AccessToken { get; set; }
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int Salt { get; set; }
        public string? DisplayName { get; set; }
        public string? Avarta { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Sex { get; set; }
        public string Mobile { get; set; } = null!;
        public string? Email { get; set; }
        public string? Company { get; set; }
        public string? Role { get; set; }
        public bool IsAdminUser { get; set; }
        public bool? IsLocked { get; set; }
        public string? Session { get; set; }
        public string? SessionId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
