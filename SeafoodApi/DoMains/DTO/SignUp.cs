﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoMains.DTO
{
    public class SignUp
    {
        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string? DisplayName { get; set; }

        public string? Avarta { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Sex { get; set; }

        public string Mobile { get; set; } = null!;

        public string? Email { get; set; }

        public string? Company { get; set; }
    }
}
