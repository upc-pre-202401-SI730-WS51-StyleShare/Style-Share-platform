using styleshareCategories_platform.CategoryService.Domain.Model.Entities;
using styleshareCategories_platform.CategoryService.Domain.Model.Queries;

namespace styleshareCategories_platform.CategoryService.Domain.Services;

public interface ICategoryQueryService
{

    Task<Category?> Handle(GetCategoryByIdQuery getProfileByIdQuery);
    
    Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query);
    
    Task<IEnumerable<Category>> Handle(GetFavoriteCategoriesQuery query);

}