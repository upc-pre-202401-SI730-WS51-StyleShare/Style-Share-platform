using styleshareCategories_platform.CategoryService.Domain.Model.Entities;

namespace styleshareCategories_platform.CategoryService.Domain.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task AddCategoryAsync(Category category);
    Task DeleteCategoryAsync(int categoryId);
    
    Task<Category?> GetCategoryByIdAsync(int categoryId);
    Task UpdateCategoryAsync(Category category);
    
    Task<IEnumerable<Category>> GetFavoriteCategoriesAsync();

}