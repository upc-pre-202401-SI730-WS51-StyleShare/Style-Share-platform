namespace styleshareCategories_platform.CategoryService.Domain.Model.Commands;

public record CreateCategoryCommand(
    long Price_range,
    string Category_type,
    string Category_name,
    string Image2,
    string Description,
    float Rate,
    bool Isfavorite)
{
    public CreateCategoryCommand() : this(default, "", "", "", "", 0, false)
    {
    }
}
