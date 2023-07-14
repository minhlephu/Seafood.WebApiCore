using AutoMapper;
using Domains.DTOs;
using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryServices.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, SignInRequest>().ReverseMap();            
            CreateMap<User, SignInResponse>().ReverseMap();
            
            CreateMap<User, SignUpRequest>().ReverseMap();
            CreateMap<User, SignUpResponse>().ReverseMap();

            CreateMap<User, UserResponse>().ReverseMap();
        }
    }
}
