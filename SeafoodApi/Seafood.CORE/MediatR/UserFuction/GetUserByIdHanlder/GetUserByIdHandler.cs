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

namespace Seafood.CORE.MediatR.UserFuction.GetUserByIdHanlder
{
    public record GetUserByIdCommand(string Id) : IRequest<UserMediatResultModel>;
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdCommand, UserMediatResultModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserMediatResultModel> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(Guid.Parse(request.Id));
            return _mapper.Map<User, UserMediatResultModel>(user);
        }
    }
}
