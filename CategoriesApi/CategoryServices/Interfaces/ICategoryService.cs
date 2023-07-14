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
        Task<IEnumerable<CreateOrUpdateCategoryResponse>> GetCategories();

        Task<CreateOrUpdateCategoryResponse> GetCategory(Guid id);

        Task<CreateOrUpdateCategoryResponse> CreateCategory(CreateOrUpdateCategoryRequest request);

        Task<CreateOrUpdateCategoryResponse> UpdateCategory(Guid id, CreateOrUpdateCategoryRequest request);

        Task DeleteCategory(Guid id);

        Task<bool> ExistsCategoryById(Guid id);
    }
}
