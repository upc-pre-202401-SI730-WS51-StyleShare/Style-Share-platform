using Style_Share_Platform.CategoryService.Domain.Model.Entities;
using Style_Share_Platform.CategoryService.Interfaces.Rest.Resources;

namespace Style_Share_Platform.CategoryService.Interfaces.Rest.Trasform;

public static class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        return new CategoryResource(entity.Id, entity.Price_range, entity.Category_type,entity.Category_name,entity.Image2,entity.Description,entity.Rate,entity.Isfavorite);
    }
}