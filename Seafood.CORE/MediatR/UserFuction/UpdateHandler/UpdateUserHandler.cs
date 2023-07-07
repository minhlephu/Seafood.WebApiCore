using AutoMapper;
using MediatR;
using Seafood.ARCHITECTURE.Entities.Models;
using Seafood.CORE.MediatR.UserFuction.Model;
using Seafood.CORE.Repositories.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.CORE.MediatR.UserFuction.UpdateHandler
{
    public record UpdateUserCommand(UserMediatUpdateModel UserMediatUpdateModel) : IRequest<UserMediatResultModel>;

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserMediatResultModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserMediatResultModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Update(request.UserMediatUpdateModel.Id, request.UserMediatUpdateModel.Username, request.UserMediatUpdateModel.Password, request.UserMediatUpdateModel.Role);
            if (user != null)
            {
                return _mapper.Map<User, UserMediatResultModel>(user);
            }
            else
                return null;
        }
    }
}
