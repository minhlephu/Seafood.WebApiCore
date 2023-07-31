using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(Guid id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task Delete(T entity);

        Task<bool> IsExisted(Expression<Func<T, bool>> expression);
    }
}
