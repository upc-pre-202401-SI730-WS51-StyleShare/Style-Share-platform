using Style_Share_Platform.Publications.Domain.Model.Commands;
using Style_Share_Platform.Publications.Interfaces.REST.Resources;

namespace Style_Share_Platform.Publications.Interfaces.REST.Transform;

public class CreatePublicationCommandFromResourceAssembler
{
    public static CreatePublicationCommand ToCommandFromResource(CreatePublicationResource resource)
    {
        return new CreatePublicationCommand(resource.cost, resource.garmentId, resource.lessorId, resource.rating);
    }
}