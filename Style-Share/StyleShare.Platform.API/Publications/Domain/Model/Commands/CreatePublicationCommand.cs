namespace StyleShare.Platform.API.Publications.Domain.Model.Commands;

public record CreatePublicationCommand(double cost, int garmentId, int lessorId, int rating);