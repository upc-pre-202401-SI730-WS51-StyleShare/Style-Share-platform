namespace Style_Share_Platform.Publications.Domain.Model.Commands;

public record UpdateCommentCommand(int commentId ,string title, int punctuation, string description);