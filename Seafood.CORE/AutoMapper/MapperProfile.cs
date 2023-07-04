using AutoMapper;
using Seafood.ARCHITECTURE.Entities.Models;
using Seafood.CORE.Base.Models;
using Seafood.CORE.MediatR.AuthenticationFunction.LoginHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.CORE.AutoMapper
{
    public class MapperProfile : Profile
    {
       public MapperProfile() { 
            CreateMap<User, LoginMediatResultModel>();
            CreateMap<LoginMediatResultModel, JwtModel>();
       }
    }
}
