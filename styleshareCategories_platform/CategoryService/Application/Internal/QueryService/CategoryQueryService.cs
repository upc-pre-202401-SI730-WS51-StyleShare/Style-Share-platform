using styleshareCategories_platform.CategoryService.Domain.Model.Entities;
using styleshareCategories_platform.CategoryService.Domain.Model.Queries;
using styleshareCategories_platform.CategoryService.Domain.Repositories;
using styleshareCategories_platform.CategoryService.Domain.Services;

namespace styleshareCategories_platform.CategoryService.Application.Internal.QueryService;

public class CategoryQueryService(ICategoryRepository categoryRepository) : ICategoryQueryService
{
    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query)
    {
        return await categoryRepository.GetAllCategoriesAsync();
    }

    public async Task<Category?> Handle(GetCategoryByIdQuery query)
    {
        return await categoryRepository.GetCategoryByIdAsync(query.CategoryID);

    }
    
    public async Task<IEnumerable<Category>> Handle(GetFavoriteCategoriesQuery query)
    {
        return await categoryRepository.GetFavoriteCategoriesAsync();
    }
}