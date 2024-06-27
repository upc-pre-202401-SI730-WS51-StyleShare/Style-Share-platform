using Microsoft.EntityFrameworkCore;
using styleshareCategories_platform.CategoryService.Domain.Model.Entities;
using styleshareCategories_platform.CategoryService.Domain.Repositories;
using styleshareCategories_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using styleshareCategories_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace styleshareCategories_platform.CategoryService.Infrastructure.Persistence.EFC.Repositories;

public class CategoryRepository(AppDBContext context) : BaseRepository<Category>(context),ICategoryRepository
{


    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task AddCategoryAsync(Category category)
    {
        context.Categories.Add(category);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(int categoryId)
    {
        var category = await context.Categories.FindAsync(categoryId);
        if (category != null)
        {
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
        }
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await context.Categories.FindAsync(id);
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        var existingCategory = await context.Categories.FindAsync(category.Id);
        if (existingCategory != null)
        {
            existingCategory.Price_range = category.Price_range;
            existingCategory.Category_type = category.Category_type;
            existingCategory.Category_name = category.Category_name;
            existingCategory.Image2 = category.Image2;
            existingCategory.Description = category.Description;
            existingCategory.Rate = category.Rate; 
            existingCategory.Isfavorite = category.Isfavorite;
            await context.SaveChangesAsync();
        }    
    }
    
    public async Task<IEnumerable<Category>> GetFavoriteCategoriesAsync()
    {
        return await context.Categories.Where(c => c.Isfavorite).ToListAsync();
    }
}