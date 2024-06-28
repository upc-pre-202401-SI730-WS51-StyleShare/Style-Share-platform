namespace Style_Share_Platform.Publications.Interfaces.REST.Resources;

public record CommentResource(int Id, string Title, int Punctuation, string Description, int PublicationId);