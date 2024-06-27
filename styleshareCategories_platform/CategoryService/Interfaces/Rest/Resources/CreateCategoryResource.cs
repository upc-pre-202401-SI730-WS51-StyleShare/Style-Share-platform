namespace styleshareCategories_platform.CategoryService.Interfaces.Rest.Resources;

public record CreateCategoryResource(long Price_range, string Category_type, string Category_name, string Image2, string Description, float Rate, bool Isfavorite);