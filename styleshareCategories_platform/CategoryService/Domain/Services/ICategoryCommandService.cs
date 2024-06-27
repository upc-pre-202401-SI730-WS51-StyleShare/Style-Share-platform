using styleshareCategories_platform.CategoryService.Domain.Model.Commands;
using styleshareCategories_platform.CategoryService.Domain.Model.Entities;

namespace styleshareCategories_platform.CategoryService.Domain.Services;

public interface ICategoryCommandService
{
    Task<Category?> Handle(CreateCategoryCommand command);
    Task<Category?> Handle(DeleteCategoryByIdCommand command);
    Task<Category?> Handle(UpdateCategoryCommand command);
}