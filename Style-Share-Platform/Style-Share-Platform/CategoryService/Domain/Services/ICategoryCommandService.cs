using Style_Share_Platform.CategoryService.Domain.Model.Commands;
using Style_Share_Platform.CategoryService.Domain.Model.Entities;

namespace Style_Share_Platform.CategoryService.Domain.Services;

public interface ICategoryCommandService
{
    Task<Category?> Handle(CreateCategoryCommand command);
    Task<Category?> Handle(DeleteCategoryByIdCommand command);
    Task<Category?> Handle(UpdateCategoryCommand command);
}