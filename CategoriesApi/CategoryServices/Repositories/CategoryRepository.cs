using CategoryServices.Interfaces;
using Domains.AppDbContexts;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryServices.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        private readonly SeafoodContext _context;

        public CategoryRepository(SeafoodContext context)
        {
            _context = context;
        }

        public async Task DeleteById(Guid id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(_ => _.Id == id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(Guid id)
        {
            return await _context.Categories.AnyAsync(_ => _.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _context.Categories.FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<Category> Save(Category category)
        {
            var entity = _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
