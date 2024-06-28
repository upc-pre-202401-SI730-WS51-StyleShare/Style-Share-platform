namespace StyleShare.Platform.API.Publications.Domain.Model.Commands;

public record AddCommentToPublicationCommand(int commentId, int publicationId);