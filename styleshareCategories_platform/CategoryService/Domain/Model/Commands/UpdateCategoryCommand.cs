namespace styleshareCategories_platform.CategoryService.Domain.Model.Commands;

public class UpdateCategoryCommand
{
    public int Id { get; set; }

    public long Price_range { get; set; }

    public string Category_type { get; set; }

    public string Category_name { get; set; }

    public string Image2 { get; set; }
    
    public string Description { get; set; }
    
    public float Rate { get; set; }
    
    public bool Isfavorite { get; set; }

    
    public UpdateCategoryCommand(long Price_range, string Category_type, string Category_name, string Image2, string Description, float Rate, bool Isfavorite)
    {
        Price_range = Price_range;
        Category_type = Category_type;
        Category_name = Category_name;
        Image2 = Image2;
        Description = Description;
        Rate = Rate;
        Isfavorite = Isfavorite;
    }

    public UpdateCategoryCommand()
    {
        
    }
}