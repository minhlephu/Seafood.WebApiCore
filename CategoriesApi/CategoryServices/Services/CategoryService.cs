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
        private readonly IGenericRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryResponse> Create(CategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            category.Id = Guid.NewGuid();
            category.CreatedAt = DateTime.UtcNow;
            category.CreatedBy = "dev_local";
            var response = await _repository.Save(category);
            return _mapper.Map<CategoryResponse>(response);
        }       

        public async Task DeleteById(Guid id)
        {
            await _repository.DeleteById(id);
        }

        public async Task<bool> ExistsById(Guid id)
        {
            return await _repository.ExistsById(id);
        }

        public async Task<IEnumerable<CategoryResponse>> GetAll()
        {
            var categories = await _repository.GetAll();
            var reponses = categories.Select(c => _mapper.Map<CategoryResponse>(c));
            return reponses;
        }

        public async Task<CategoryResponse> GetById(Guid id)
        {
            var category = await _repository.GetById(id);
            return _mapper.Map<CategoryResponse>(category);
        }

        public async Task<CategoryResponse> Update(Guid id, CategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            category.Id = id;
            category.UpdatedAt = DateTime.UtcNow;
            category.CreatedBy = "dev_local";
            var response = await _repository.Update(category);
            return _mapper.Map<CategoryResponse>(response);
        }
    }
}
