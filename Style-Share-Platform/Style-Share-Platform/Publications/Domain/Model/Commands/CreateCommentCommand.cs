namespace Style_Share_Platform.Publications.Domain.Model.Commands;

public record CreateCommentCommand(string title, int punctuation, string description, int publicationId);