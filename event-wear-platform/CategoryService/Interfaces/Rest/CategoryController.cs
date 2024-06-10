using event_wear_platform.CategoryService.Domain.Model.Aggregates;
using event_wear_platform.CategoryService.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace event_wear_platform.CategoryService.Interfaces.Rest;

[ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("create")]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Category cannot be null");
            }

            try
            {
                _categoryService.CreateCategory(category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                // Log the exception details here
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get category by ID", Description = "Retrieves the details of a category by its ID.")]
        [SwaggerResponse(200, "Category retrieved successfully", typeof(Category))]
        [SwaggerResponse(404, "Category not found")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPut("{categoryId}")]
        public IActionResult UpdateCategory(string categoryId, [FromBody] Category updatedCategory)
        {
            var category = _categoryService.GetCategoryById(categoryId);

            if (category == null)
            {
                return NotFound();
            }
/*
            category.Name = updatedCategory.Name;
            category.Description = updatedCategory.Description;
            category.Status = updatedCategory.Status;
            category.IsFavorite = updatedCategory.IsFavorite;
*/
            _categoryService.UpdateCategory(category);

            return Ok(category);
        }

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(string categoryId)
        {
            var category = _categoryService.GetCategoryById(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            _categoryService.DeleteCategory(category);

            return NoContent();
        }

        [HttpPut("{categoryId}/favorite")]
        public IActionResult MarkCategoryAsFavorite(string categoryId)
        {
            var category = _categoryService.GetCategoryById(categoryId);

            if (category == null)
            {
                return NotFound();
            }
/*
            category.IsFavorite = true;
*/
            _categoryService.UpdateCategory(category);

            return Ok(category);
        }
    }