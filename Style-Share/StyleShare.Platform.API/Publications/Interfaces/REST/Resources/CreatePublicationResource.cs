namespace StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

public record CreatePublicationResource(double cost, int garmentId, int lessorId, int rating);