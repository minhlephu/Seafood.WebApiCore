﻿using Seafood.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Application.Repositories.Categories
{
    public interface ICategoryRepository
    {
        Task<List<CategoryVM>> GetAll();
        Task<CategoryVM> Create(CategoryRequest request);
        Task<bool> Update(Guid id, CategoryRequest request);
        Task<bool> Delete(Guid id);
    }
}