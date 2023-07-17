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
        Task<IEnumerable<CreateOrUpdateCategoryResponse>> GetAll();

        Task<CreateOrUpdateCategoryResponse> GetById(Guid id);

        Task<CreateOrUpdateCategoryResponse> Create(CreateOrUpdateCategoryRequest request);

        Task<CreateOrUpdateCategoryResponse> Update(Guid id, CreateOrUpdateCategoryRequest request);

        Task DeleteById(Guid id);

        Task<bool> ExistsById(Guid id);
    }
}
