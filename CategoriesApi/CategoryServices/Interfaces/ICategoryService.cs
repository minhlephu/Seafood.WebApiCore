using Domains.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryServices.Interfaces
{
    public interface ICategoryService 
    {
        Task<IEnumerable<CategoryResponse>> GetAll();

        Task<CategoryResponse> GetById(Guid id);

        Task<CategoryResponse> Create(CategoryRequest request);

        Task<CategoryResponse> Update(Guid id, CategoryRequest request);

        Task DeleteById(Guid id);

        Task<bool> ExistsById(Guid id);
    }
}
