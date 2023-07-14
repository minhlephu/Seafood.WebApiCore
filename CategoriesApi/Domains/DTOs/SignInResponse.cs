﻿using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.DTOs
{
    public class SignInResponse
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = null!;

        public string Token { get; set; }

        public string? DisplayName { get; set; }

        public string? Avarta { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Sex { get; set; }

        public string Mobile { get; set; } = null!;

        public string? Email { get; set; }

        public string? Company { get; set; }

        public string? Session { get; set; }

        public string? SessionId { get; set; }       

        public SignInResponse() { }

        public SignInResponse(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            DisplayName = user.DisplayName;
            Mobile = user.Mobile;
            Sex = user.Sex;
            Avarta = user.Avarta;
            Birthday = user.Birthday;
            Company = user.Company;            
            Session = user.Session;
            SessionId = user.SessionId;
        }
    }
}
