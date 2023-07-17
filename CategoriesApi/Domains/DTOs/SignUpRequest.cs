using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.DTOs
{
    public class SignUpRequest
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? DisplayName { get; set; }

        public string Mobile { get; set; } = null!;

        public string Email { get; set; }        
    }
}
