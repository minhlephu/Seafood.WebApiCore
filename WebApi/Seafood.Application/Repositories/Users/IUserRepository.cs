using Seafood.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Application.Repositories.Users
{
    public interface IUserRepository
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
