namespace event_wear_platform.CategoryService.Domain.Model.Entities;

public class Publication
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
        
    public string CategoryId { get; set; }
    public CategoryService.Domain.Model.Aggregates.Category Category { get; set; }
}