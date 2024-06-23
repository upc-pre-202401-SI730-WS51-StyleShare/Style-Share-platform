using StyleShare.Platform.API.Publications.Domain.Model.Commands;
using StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Publications.Interfaces.REST.Transform;

public class UpdatePublicationCommandFromResourceAssembler
{
    public static UpdatePublicationCommand ToCommandFromResource(UpdatePublicationResource resource, int publicationId)
    {
        return new UpdatePublicationCommand(publicationId, resource.cost, resource.garmentId,
            resource.lessorId, resource.rating);
    }
}