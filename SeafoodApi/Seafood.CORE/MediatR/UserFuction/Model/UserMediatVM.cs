using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.CORE.MediatR.UserFuction.Model
{
    public class UserMediatVM
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public int Sex { get; set; }
        public string Mobile { get; set; }
    }
}
