using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace styleshareCategories_platform.CategoryService.Domain.Model.Entities;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public long Price_range { get; set; }

    public string Category_type { get; set; }

    public string Category_name { get; set; }

    public string Image2 { get; set; }
    
    public string Description { get; set; }
    
    public float Rate { get; set; }
    
    public bool Isfavorite { get; set; }
}