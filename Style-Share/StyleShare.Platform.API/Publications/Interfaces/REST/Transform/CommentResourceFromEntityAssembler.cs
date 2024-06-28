using StyleShare.Platform.API.Publications.Domain.Model.Entities;
using StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Publications.Interfaces.REST.Transform;

public class CommentResourceFromEntityAssembler
{
    public static CommentResource ToResourceFromEntity(Comment comment)
    {
        return new CommentResource(comment.Id, comment.Title, comment.Punctuation, 
            comment.Description, comment.PublicationId);
    }
}