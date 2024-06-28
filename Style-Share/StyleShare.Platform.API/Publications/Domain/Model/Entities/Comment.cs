namespace StyleShare.Platform.API.Publications.Domain.Model.Entities;

public partial class Comment
{
    public int Id { get; }
    public string Title { get; private set; }
    public int Punctuation { get; private set; }
    public string Description { get; private set; }
    public int PublicationId { get; private set; }
    
    public Comment(string title, int punctuation, string description, int publicationId)
    {
        Title = title;
        Punctuation = punctuation;
        Description = description;
        PublicationId = publicationId;
    }

    public void EditComment(string title, int punctuation, string description)
    {
        Title = title;
        Punctuation = punctuation;
        Description = description;
    }
}