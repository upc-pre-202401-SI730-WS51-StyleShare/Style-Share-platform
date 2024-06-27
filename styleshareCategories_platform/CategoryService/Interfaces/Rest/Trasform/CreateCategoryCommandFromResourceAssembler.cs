using styleshareCategories_platform.CategoryService.Domain.Model.Commands;
using styleshareCategories_platform.CategoryService.Interfaces.Rest.Resources;

namespace styleshareCategories_platform.CategoryService.Interfaces.Rest.Trasform;

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