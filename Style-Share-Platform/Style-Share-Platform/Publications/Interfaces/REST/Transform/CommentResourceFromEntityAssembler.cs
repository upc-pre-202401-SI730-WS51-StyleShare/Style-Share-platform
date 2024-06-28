using Style_Share_Platform.Publications.Interfaces.REST.Resources;
using Comment = Style_Share_Platform.Publications.Domain.Model.Entities.Comment;

namespace Style_Share_Platform.Publications.Interfaces.REST.Transform;

public class CommentResourceFromEntityAssembler
{
    public static CommentResource ToResourceFromEntity(Comment comment)
    {
        return new CommentResource(comment.Id, comment.Title, comment.Punctuation, 
            comment.Description, comment.PublicationId);
    }
}