using Comment = Style_Share_Platform.Publications.Domain.Model.Entities.Comment;

namespace Style_Share_Platform.Publications.Interfaces.REST.Resources;

public record PublicationResource(int Id, double cost, int garmentId, int lessorId, int rating, ICollection<Comment> comments);