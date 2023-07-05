using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Seafood.ARCHITECTURE.Entities.Models;
using Seafood.CORE.Repositories.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.CORE.MediatR.UserFuction.GetUserHandler
{
    public record GetAllUserQuery : IRequest<IEnumerable<UserMediatResultModel>>;
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserMediatResultModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserMediatResultModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var listUserModels = await _userRepository.GetAll();
            List<UserMediatResultModel> userMediatResultModels = new List<UserMediatResultModel>();
            foreach (var item in listUserModels)
            {
                userMediatResultModels.Add(_mapper.Map<User, UserMediatResultModel>(item));
            }
            return userMediatResultModels;
        }
    }

    public class UserMediatResultModel
    {
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
        public string Role { get; set; }
        public bool IsAdminUser { get; set; }
        public bool IsLocked { get; set; }
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
