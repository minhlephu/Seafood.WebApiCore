using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryServices.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> FindAll();

        Task<Category> FindById(Guid id);

        Task<Category> Save(Category category);

        Task<Category> Update(Category category);

        Task DeleteById(Guid id);

        Task<bool> ExistsById(Guid id);
    }
}
