using CategoryServices.Interfaces;
using Domains.AppDbContexts;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryServices.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SeafoodContext _context;

        public UserRepository(SeafoodContext context)
        {
            _context = context;
        }

        public async Task DeleteById(Guid id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByEmail(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> ExistsById(Guid id)
        {
            return await _context.Users.AnyAsync(_ => _.Id == id);
        }

        public async Task<bool> ExistsByUsername(string username)
        {
            return await _context.Users.AnyAsync(_ => _.Username == username);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(_ => _.Username == username);
        }

        public async Task<User> Save(User user)
        {
            var entity = _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public Task<User> Update(User entity)
        {
            return null;
        }
    }
}
