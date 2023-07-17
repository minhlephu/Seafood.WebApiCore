using CategoriesApi.Configurations;
using CategoryServices.Interfaces;
using Domains.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CategoriesApi.Controllers
{
    [Authorize(Domains.Models.Role.User)]
    [ApiController]
    [Route("/api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _categoryService.GetAll();
                if (categories == null)
                {
                    return NoContent();
                }
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _categoryService.Create(request);
            return CreatedAtAction("GetCategory", new { id = response.Id }, response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, CategoryRequest request)
        {
            if(!ExistsCategoryById(id).Result)
            {
                return NotFound("Id is not found!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }            
            var response = await _categoryService.Update(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            if(!ExistsCategoryById(id).Result)
            {
                return NotFound("Id is not found!");
            }
            await _categoryService.DeleteById(id);
            return Ok(new {message = "Deleted success!"});
        }

        private async Task<bool> ExistsCategoryById(Guid id)
        {
            return await _categoryService.ExistsById(id);
        }
    }
}
