using Style_Share_Platform.Publications.Domain.Model.Commands;
using Style_Share_Platform.Publications.Interfaces.REST.Resources;

namespace Style_Share_Platform.Publications.Interfaces.REST.Transform;

public class CreateCommentCommandFromResourceAssembler
{
    public static CreateCommentCommand ToCommandFromResource(CreateCommentResource resource)
    {
        return new CreateCommentCommand(resource.title, resource.punctuation, resource.description, resource.publicationId);
    }
}