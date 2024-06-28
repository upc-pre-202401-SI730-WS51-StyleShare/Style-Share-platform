namespace Style_Share_Platform.Publications.Interfaces.REST.Resources;

public record CreateCommentResource(string title, int punctuation, string description, int publicationId);