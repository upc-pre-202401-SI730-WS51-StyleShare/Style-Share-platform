namespace StyleShare.Platform.API.Publications.Domain.Model.Commands;

public record CreateCommentCommand(string title, int punctuation, string description, int publicationId);