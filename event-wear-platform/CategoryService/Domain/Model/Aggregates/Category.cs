using event_wear_platform.CategoryService.Domain.Model.Entities;

namespace event_wear_platform.CategoryService.Domain.Model.Aggregates;

public class Category
{
    public Category(string id, string name, string description, bool isFavorite, string status)
    {
        Id = id;
        Name = name;
        Description = description;
        IsFavorite = isFavorite;
        Status = status;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsFavorite { get; set; }
    public string Status { get; set; }
        
    public ICollection<Publication> Publications { get; set; } = new List<Publication>();
        
    public void AddPublication(Publication publication)
    {
        Publications.Add(publication);
        publication.Category = this;
    }
        
    public void RemovePublication(Publication publication)
    {
        Publications.Remove(publication);
        publication.Category = null;
    }
}