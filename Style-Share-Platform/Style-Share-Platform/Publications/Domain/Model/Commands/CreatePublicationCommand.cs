namespace Style_Share_Platform.Publications.Domain.Model.Commands;

public record CreatePublicationCommand(double cost, int garmentId, int lessorId, int rating);