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
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Lập trình chỉ chỉnh sửa được password và role
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<User> Update(Guid Id, string username, string role, int sex, string mobile)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Id == Id);
            if (user != null)
            {
                user.Username = username;
                user.Role = role;
                user.Sex = sex;
                user.Mobile = mobile;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            else
                return null;
        }
    }
}
