using event_wear_platform.CategoryService.Domain.Model.Aggregates;

namespace event_wear_platform.CategoryService.Domain.Repositories;

public interface ICategoryRepository
{
    Task<CategoryService.Domain.Model.Aggregates.Category> GetByIdAsync(string id);
    Task UpdateCategory(object existingCategory);
    Task<Category> GetCategoryById(string id);
}