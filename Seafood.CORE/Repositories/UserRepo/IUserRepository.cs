﻿using Seafood.ARCHITECTURE.Entities.Models;
using Seafood.INFRASTRUCTURE.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.CORE.Repositories.UserRepo
{
    public interface IUserRepository : IGenericRepository<User>
    {
        bool IsAdmin(User user);

        Task<User> Login(string username, string passwordHash);
    }
}