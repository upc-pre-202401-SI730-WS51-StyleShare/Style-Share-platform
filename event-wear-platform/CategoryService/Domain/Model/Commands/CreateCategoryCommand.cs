namespace event_wear_platform.CategoryService.Domain.Model.Commands;

public class CreateCategoryCommand
{
    public CreateCategoryCommand(string id, string name, string description, string status, bool isFavorite)
    {
        Id = id;
        Name = name;
        Description = description;
        Status = status;
        IsFavorite = isFavorite;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public bool IsFavorite { get; set; }
}