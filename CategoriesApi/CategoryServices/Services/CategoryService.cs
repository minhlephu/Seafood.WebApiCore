using AutoMapper;
using CategoryServices.Interfaces;
using Domains.DTOs;
using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryServices.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateOrUpdateCategoryResponse> CreateCategory(CreateOrUpdateCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            category.Id = Guid.NewGuid();
            category.CreatedAt = DateTime.UtcNow;
            category.CreatedBy = "dev_local";
            var response = await _repository.Save(category);
            return _mapper.Map<CreateOrUpdateCategoryResponse>(response);

        }

        public async Task DeleteCategory(Guid id)
        {
            await _repository.DeleteById(id);
        }

        public async Task<bool> ExistsCategoryById(Guid id)
        {
            return await _repository.ExistsById(id);
        }

        public async Task<IEnumerable<CreateOrUpdateCategoryResponse>> GetCategories()
        {
            var categories = await _repository.FindAll();
            var reponses = categories.Select(c => _mapper.Map<CreateOrUpdateCategoryResponse>(c));
            return reponses;
        }

        public async Task<CreateOrUpdateCategoryResponse> GetCategory(Guid id)
        {
            var category = await _repository.FindById(id);
            return _mapper.Map<CreateOrUpdateCategoryResponse>(category);
        }

        public async Task<CreateOrUpdateCategoryResponse> UpdateCategory(Guid id, CreateOrUpdateCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            category.Id = id;
            category.UpdatedAt = DateTime.UtcNow;
            category.CreatedBy = "dev_local";
            var response = await _repository.Update(category);
            return _mapper.Map<CreateOrUpdateCategoryResponse>(response);
        }
    }
}
