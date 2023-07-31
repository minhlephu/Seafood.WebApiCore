using _2DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Model.AppDbContexts;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SeafoodContext context) : base(context) { }

        public async Task<User> GetByUserName(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(_ => _.Username == username);
        }
    }
}
