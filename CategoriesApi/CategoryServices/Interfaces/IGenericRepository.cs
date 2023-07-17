using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryServices.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(Guid id);

        Task<T> Save(T entity);

        Task<T> Update(T entity);

        Task DeleteById(Guid id);

        Task<bool> ExistsById(Guid id);
    }
}
