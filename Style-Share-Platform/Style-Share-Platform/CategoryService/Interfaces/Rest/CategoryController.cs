using Microsoft.AspNetCore.Mvc;
using Style_Share_Platform.CategoryService.Domain.Model.Commands;
using Style_Share_Platform.CategoryService.Domain.Model.Queries;
using Style_Share_Platform.CategoryService.Domain.Repositories;
using Style_Share_Platform.CategoryService.Domain.Services;
using Style_Share_Platform.CategoryService.Interfaces.Rest.Resources;
using Style_Share_Platform.CategoryService.Interfaces.Rest.Trasform;
using Swashbuckle.AspNetCore.Annotations;

namespace Style_Share_Platform.CategoryService.Interfaces.Rest;

[ApiController]
[Route("")]
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
    [SwaggerOperation(Summary = "Get category by id")]
    [HttpGet("{categoryId:int}")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var getCategoryByIdQuery = new GetCategoryByIdQuery(categoryId);
        var category = await categoryQueryService.Handle(getCategoryByIdQuery);
        if (category == null) return NotFound();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }
    
    [SwaggerOperation(Summary = "Create new category")]
    [HttpPost]
    public async Task<ActionResult> AddCategory(CreateCategoryResource resource)
    {
        var createCategoryCommand = CreateCategoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var category = await categoryCommandService.Handle(createCategoryCommand);
        if (category == null) return BadRequest();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return CreatedAtAction(nameof(GetCategoryById), new { categoryId = categoryResource.Id }, categoryResource);
    }

    [SwaggerOperation(Summary = "Get all categories")]
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var getAllCategoriesQuery = new GetAllCategoriesQuery();
        var categories = await categoryQueryService.Handle(getAllCategoriesQuery);
        var resources = categories.Select(CategoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [SwaggerOperation(Summary = "Delete category by id")]
    [HttpDelete("{categoryId:int}")]
    public async Task<IActionResult> DeleteCategoryById(int categoryId)
    {
        var deleteCategoryCommand = new DeleteCategoryByIdCommand(categoryId);
        await categoryCommandService.Handle(deleteCategoryCommand);
        return NoContent();
    }
    
    [SwaggerOperation(Summary = "Update category by id")]
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
    
    [SwaggerOperation(Summary = "Get favorite categories")]
    [HttpGet("/favorites")]
    public async Task<IActionResult> GetFavoriteCategories()
    {
        var query = new GetFavoriteCategoriesQuery();
        var result = await categoryQueryService.Handle(query);
        return Ok(result);
    }
}
