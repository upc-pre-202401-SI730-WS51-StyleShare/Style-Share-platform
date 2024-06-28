using Style_Share_Platform.CategoryService.Domain.Model.Commands;
using Style_Share_Platform.CategoryService.Domain.Model.Entities;
using Style_Share_Platform.CategoryService.Domain.Repositories;
using Style_Share_Platform.CategoryService.Domain.Services;
using Style_Share_Platform.Shared.Domain.Repositories;

namespace Style_Share_Platform.CategoryService.Application.Internal.CommandService;

public class CategoryCommandService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : ICategoryCommandService
{
    public async Task<Category?> Handle(CreateCategoryCommand command)
    {
        var category = new Category
        {
            Price_range = command.Price_range,
            Category_type = command.Category_type,
            Category_name = command.Category_name,
            Image2 = command.Image2,
            Description = command.Description,
            Rate = command.Rate,
            Isfavorite = command.Isfavorite
        };

        await categoryRepository.AddCategoryAsync(category);
        return category;
    }

    public async Task<Category?> Handle(DeleteCategoryByIdCommand command)
    {
        var category = await categoryRepository.GetCategoryByIdAsync(command.CategoryId);
        if (category == null)
        {
            return null;
        }

        await categoryRepository.DeleteCategoryAsync(category.Id);
        return category;
    }
    public async Task<Category?> Handle(UpdateCategoryCommand command)
    {
        var category = await categoryRepository.GetCategoryByIdAsync(command.Id);
        if (category == null)
        {
            return null; 
        }

        category.Price_range = command.Price_range;
        category.Category_type = command.Category_type;
        category.Category_name = command.Category_name;
        category.Image2 = command.Image2;
        category.Description = command.Description;
        category.Rate = command.Rate; 
        category.Isfavorite = command.Isfavorite;

        await categoryRepository.UpdateCategoryAsync(category);
        return category;
    }
}