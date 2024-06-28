using Style_Share_Platform.Publications.Domain.Model.Commands;
using Style_Share_Platform.Publications.Interfaces.REST.Resources;

namespace Style_Share_Platform.Publications.Interfaces.REST.Transform;

public class UpdateCommentCommandFromResourceAssembler
{
    public static UpdateCommentCommand ToCommandFromResource(UpdateCommentResource resource, int commentId)
    {
        return new UpdateCommentCommand(commentId, resource.title, resource.punctuation, resource.description);
    }
}