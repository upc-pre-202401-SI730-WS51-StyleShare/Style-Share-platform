namespace Style_Share_Platform.Publications.Interfaces.REST.Resources;

public record CreatePublicationResource(double cost, int garmentId, int lessorId, int rating);