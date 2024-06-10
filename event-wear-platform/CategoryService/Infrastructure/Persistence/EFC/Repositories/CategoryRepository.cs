using event_wear_platform.CategoryService.Domain.Model.Aggregates;
using event_wear_platform.CategoryService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace event_wear_platform.CategoryService.Infrastructure.Persistence.EFC.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly CategoryDbContext _context;

    public CategoryRepository(CategoryDbContext context)
    {
        _context = context;
    }

    public async Task<CategoryService.Domain.Model.Aggregates.Category> GetByIdAsync(string id)
    {
        return await _context.Categories.Include(c => c.Publications).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(CategoryService.Domain.Model.Aggregates.Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CategoryService.Domain.Model.Aggregates.Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var category = await GetByIdAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }

    public Task Add(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetCategoryByIdAsync(string categoryId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategory(object existingCategory)
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetCategoryById(string id)
    {
        throw new NotImplementedException();
    }
}