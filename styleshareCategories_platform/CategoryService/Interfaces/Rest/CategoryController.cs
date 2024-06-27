using Microsoft.AspNetCore.Mvc;
using styleshareCategories_platform.CategoryService.Domain.Model.Commands;
using styleshareCategories_platform.CategoryService.Domain.Model.Queries;
using styleshareCategories_platform.CategoryService.Domain.Repositories;
using styleshareCategories_platform.CategoryService.Domain.Services;
using styleshareCategories_platform.CategoryService.Interfaces.Rest.Resources;
using styleshareCategories_platform.CategoryService.Interfaces.Rest.Trasform;

namespace styleshareCategories_platform.CategoryService.Interfaces.Rest;

[Route("")]
[ApiController]
public class CategoryController(ICategoryCommandService categoryCommandService, ICategoryQueryService categoryQueryService, ICategoryRepository categoryRepository) : ControllerBase
{
    /*
    [HttpGet("{categoryId:int}")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var getCategoryByIdQuery = new GetCategoryByIdQuery(categoryId);
        var category = await categoryQueryService.Handle(getCategoryByIdQuery);
        if (category == null) return NotFound();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }
    
    [HttpPost]
    public async Task<ActionResult> AddCategory(CreateCategoryResource resource)
    {
        
        //var category = await _categoryService.AddCategoryAsync(resource.ToEntity());
        //return Ok(category.ToResource());
        
        var createProfileCommand = CreateCategoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var profile = await categoryCommandService.Handle(createProfileCommand);
        if (profile is null) return BadRequest();
        var profileResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetProfileById), new { profileId = profileResource.Id }, profileResource);

    }
    */
    [HttpGet("{categoryId:int}")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var getCategoryByIdQuery = new GetCategoryByIdQuery(categoryId);
        var category = await categoryQueryService.Handle(getCategoryByIdQuery);
        if (category == null) return NotFound();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }
    
    [HttpPost]
    public async Task<ActionResult> AddCategory(CreateCategoryResource resource)
    {
        var createCategoryCommand = CreateCategoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var category = await categoryCommandService.Handle(createCategoryCommand);
        if (category == null) return BadRequest();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return CreatedAtAction(nameof(GetCategoryById), new { categoryId = categoryResource.Id }, categoryResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var getAllCategoriesQuery = new GetAllCategoriesQuery();
        var categories = await categoryQueryService.Handle(getAllCategoriesQuery);
        var resources = categories.Select(CategoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpDelete("{categoryId:int}")]
    public async Task<IActionResult> DeleteCategoryById(int categoryId)
    {
        var deleteCategoryCommand = new DeleteCategoryByIdCommand(categoryId);
        await categoryCommandService.Handle(deleteCategoryCommand);
        return NoContent();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryResource resource)
    {
        var category = await categoryRepository.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        
        category.Price_range = resource.Price_range;
        category.Category_type = resource.Category_type;
        category.Category_name = resource.Category_name;
        category.Image2 = resource.Image2;
        category.Description = resource.Description;
        category.Rate = resource.Rate;
        category.Isfavorite = resource.Isfavorite;

        await categoryRepository.UpdateCategoryAsync(category);
        return Ok(CategoryResourceFromEntityAssembler.ToResourceFromEntity(category));
    }
    
    [HttpGet("favorites")]
    public async Task<IActionResult> GetFavoriteCategories()
    {
        var query = new GetFavoriteCategoriesQuery();
        var result = await categoryQueryService.Handle(query);
        return Ok(result);
    }
}
