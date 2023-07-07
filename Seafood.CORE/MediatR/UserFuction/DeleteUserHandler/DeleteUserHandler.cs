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

namespace Seafood.CORE.MediatR.UserFuction.DeleteUserHandler
{
    public class DeleteUserCommand : IRequest<UserMediatResultModel>
    {
        public Guid Id { get; set; }
    }

    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, UserMediatResultModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserMediatResultModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<User> listUser = await _userRepository.Find(i => i.Id == request.Id);
            if (listUser != null && listUser.Count() > 0)
            {
                await _userRepository.Remove(listUser.First());
                return _mapper.Map<User, UserMediatResultModel>(listUser.First());
            }
            else
                return null;
        }
    }
}
