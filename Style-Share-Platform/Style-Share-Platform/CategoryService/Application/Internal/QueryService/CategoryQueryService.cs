using Style_Share_Platform.CategoryService.Domain.Model.Entities;
using Style_Share_Platform.CategoryService.Domain.Model.Queries;
using Style_Share_Platform.CategoryService.Domain.Repositories;
using Style_Share_Platform.CategoryService.Domain.Services;

namespace Style_Share_Platform.CategoryService.Application.Internal.QueryService;

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