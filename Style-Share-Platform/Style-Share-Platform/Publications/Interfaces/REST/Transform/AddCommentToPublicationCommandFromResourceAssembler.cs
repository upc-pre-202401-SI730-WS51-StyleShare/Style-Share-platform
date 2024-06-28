using Style_Share_Platform.Publications.Domain.Model.Commands;
using Style_Share_Platform.Publications.Interfaces.REST.Resources;

namespace Style_Share_Platform.Publications.Interfaces.REST.Transform;

public class AddCommentToPublicationCommandFromResourceAssembler
{
    public static AddCommentToPublicationCommand ToCommandFromResource(AddCommentToPublicationResource resource, int publicationId)
    {
        return new AddCommentToPublicationCommand(resource.commentId, publicationId);
    }
}