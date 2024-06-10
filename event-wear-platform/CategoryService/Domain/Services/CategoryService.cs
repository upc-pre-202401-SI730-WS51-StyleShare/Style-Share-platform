using event_wear_platform.CategoryService.Domain.Model.Aggregates;
using event_wear_platform.CategoryService.Domain.Repositories;

namespace event_wear_platform.CategoryService.Domain.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void CreateCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<object?> GetCategoryByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    object? ICategoryService.GetCategoryById(string categoryId)
    {
        return GetCategoryById(categoryId);
    }

    public void UpdateCategory(object category)
    {
        throw new NotImplementedException();
    }

    public void DeleteCategory(object category)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> GetCategoryById(string id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task<Category> UpdateCategory(string id, Category category)
    {
        var existingCategory = await _categoryRepository.GetCategoryById(id);
        if (existingCategory == null)
        {
            return null;
        }

        existingCategory.Name = category.Name;
        existingCategory.Description = category.Description;
        existingCategory.Status = category.Status;
        existingCategory.IsFavorite = category.IsFavorite;

        await _categoryRepository.UpdateCategory(existingCategory);

        return existingCategory;
    }
    
}

public interface ICategoryService
{
    void CreateCategory(Category category);
    Task<object?> GetCategoryByIdAsync(string id);
    object? GetCategoryById(string categoryId);
    void UpdateCategory(object category);
    void DeleteCategory(object category);
}