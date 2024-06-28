namespace StyleShare.Platform.API.Publications.Domain.Model.Commands;

public record UpdatePublicationCommand(int publicationId, double cost, int garmentId, int lessorId, int rating);