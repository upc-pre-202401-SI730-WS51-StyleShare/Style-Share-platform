namespace Style_Share_Platform.CategoryService.Interfaces.Rest.Resources;

public record CategoryResource(int Id, long Price_range, string Category_type, string Category_name, string Image2, string Description, float Rate, bool Isfavorite);