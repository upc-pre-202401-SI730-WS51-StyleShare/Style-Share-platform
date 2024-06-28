namespace Style_Share_Platform.Publications.Domain.Model.Commands;

public record AddCommentToPublicationCommand(int commentId, int publicationId);