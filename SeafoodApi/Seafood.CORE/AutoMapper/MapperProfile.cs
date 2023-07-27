using AutoMapper;
using Seafood.ARCHITECTURE.Entities.Models;
using Seafood.INFRASTRUCTURE.Base.Models;
using Seafood.CORE.MediatR.AuthenticationFunction.LoginHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seafood.CORE.MediatR.UserFuction.GetUserHandler;
using Seafood.CORE.MediatR.UserFuction.AddUserHandler;
using Seafood.CORE.MediatR.UserFuction.Model;

namespace Seafood.CORE.AutoMapper
{
    public class MapperProfile : Profile
    {
       public MapperProfile() { 
            CreateMap<User, LoginMediatResultModel>();
            CreateMap<User, UserMediatResultModel>();

            CreateMap<UserMediatModel, User>();

            CreateMap<LoginMediatResultModel, JwtModel>();
       }
    }
}
