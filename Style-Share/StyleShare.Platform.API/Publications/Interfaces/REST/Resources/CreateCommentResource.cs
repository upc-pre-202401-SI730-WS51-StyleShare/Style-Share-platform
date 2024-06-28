namespace StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

public record CreateCommentResource(string title, int punctuation, string description, int publicationId);