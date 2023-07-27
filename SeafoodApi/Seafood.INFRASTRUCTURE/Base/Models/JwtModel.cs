using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.INFRASTRUCTURE.Base.Models
{
    public class JwtModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
