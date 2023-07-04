using Seafood.CORE.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.CORE.Base.Interfaces
{
    public interface IJwtService
    {
        public string CreateToken(JwtModel jwtModel);
    }
}
