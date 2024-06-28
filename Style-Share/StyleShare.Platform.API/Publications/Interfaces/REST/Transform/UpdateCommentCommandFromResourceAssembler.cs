using StyleShare.Platform.API.Publications.Domain.Model.Commands;
using StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Publications.Interfaces.REST.Transform;

public class UpdateCommentCommandFromResourceAssembler
{
    public static UpdateCommentCommand ToCommandFromResource(UpdateCommentResource resource, int commentId)
    {
        return new UpdateCommentCommand(commentId, resource.title, resource.punctuation, resource.description);
    }
}