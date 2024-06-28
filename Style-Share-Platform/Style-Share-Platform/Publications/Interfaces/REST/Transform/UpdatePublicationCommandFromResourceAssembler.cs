using Style_Share_Platform.Publications.Domain.Model.Commands;
using Style_Share_Platform.Publications.Interfaces.REST.Resources;

namespace Style_Share_Platform.Publications.Interfaces.REST.Transform;

public class UpdatePublicationCommandFromResourceAssembler
{
    public static UpdatePublicationCommand ToCommandFromResource(UpdatePublicationResource resource, int publicationId)
    {
        return new UpdatePublicationCommand(publicationId, resource.cost, resource.garmentId,
            resource.lessorId, resource.rating);
    }
}