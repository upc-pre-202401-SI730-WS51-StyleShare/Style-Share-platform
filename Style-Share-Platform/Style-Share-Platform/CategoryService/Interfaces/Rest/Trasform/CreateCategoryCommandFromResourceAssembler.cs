using Style_Share_Platform.CategoryService.Domain.Model.Commands;
using Style_Share_Platform.CategoryService.Interfaces.Rest.Resources;

namespace Style_Share_Platform.CategoryService.Interfaces.Rest.Trasform;

public static class CreateCategoryCommandFromResourceAssembler
{
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(
            resource.Price_range,
            resource.Category_type,
            resource.Category_name,
            resource.Image2,
            resource.Description,
            resource.Rate,
            resource.Isfavorite
        );
    }
}