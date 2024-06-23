namespace StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

public record UpdatePublicationResource(double cost, int garmentId, int lessorId, int rating);