using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Seafood.ARCHITECTURE.Entities.Models;
using Seafood.CORE.MediatR.UserFuction.Model;
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
}
