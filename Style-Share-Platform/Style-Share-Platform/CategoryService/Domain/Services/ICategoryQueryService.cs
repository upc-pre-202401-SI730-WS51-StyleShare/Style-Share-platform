using Style_Share_Platform.CategoryService.Domain.Model.Entities;
using Style_Share_Platform.CategoryService.Domain.Model.Queries;

namespace Style_Share_Platform.CategoryService.Domain.Services;

public interface ICategoryQueryService
{

    Task<Category?> Handle(GetCategoryByIdQuery getProfileByIdQuery);
    
    Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query);
    
    Task<IEnumerable<Category>> Handle(GetFavoriteCategoriesQuery query);

}