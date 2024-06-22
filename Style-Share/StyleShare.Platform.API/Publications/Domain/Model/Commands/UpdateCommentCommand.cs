namespace StyleShare.Platform.API.Publications.Domain.Model.Commands;

public record UpdateCommentCommand(int commentId ,string title, int punctuation, string description);