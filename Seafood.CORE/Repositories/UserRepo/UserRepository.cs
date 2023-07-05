using Microsoft.EntityFrameworkCore;
using Seafood.ARCHITECTURE.Constants;
using Seafood.ARCHITECTURE.Entities.Models;
using Seafood.INFRASTRUCTURE;
using Seafood.INFRASTRUCTURE.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.CORE.Repositories.UserRepo
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SeafoodDbContext context) : base(context)
        {

        }
        public bool IsAdmin(User user)
        {
            return user.IsAdminUser;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(i => i.Username == username);
            if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
