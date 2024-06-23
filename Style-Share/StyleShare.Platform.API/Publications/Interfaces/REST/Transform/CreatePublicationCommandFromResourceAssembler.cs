using StyleShare.Platform.API.Publications.Domain.Model.Commands;
using StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Publications.Interfaces.REST.Transform;

public class CreatePublicationCommandFromResourceAssembler
{
    public static CreatePublicationCommand ToCommandFromResource(CreatePublicationResource resource)
    {
        return new CreatePublicationCommand(resource.cost, resource.garmentId, resource.lessorId, resource.rating);
    }
}