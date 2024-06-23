using StyleShare.Platform.API.Publications.Domain.Model.Commands;
using StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Publications.Interfaces.REST.Transform;

public class AddCommentToPublicationCommandFromResourceAssembler
{
    public static AddCommentToPublicationCommand ToCommandFromResource(AddCommentToPublicationResource resource, int publicationId)
    {
        return new AddCommentToPublicationCommand(resource.commentId, publicationId);
    }
}