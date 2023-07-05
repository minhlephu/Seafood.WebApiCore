using Seafood.INFRASTRUCTURE.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.INFRASTRUCTURE.Base.Interfaces
{
    public interface IJwtService
    {
        public string CreateToken(JwtModel jwtModel);
    }
}
