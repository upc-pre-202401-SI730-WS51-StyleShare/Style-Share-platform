using StyleShare.Platform.API.Publications.Domain.Model.Commands;
using StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Publications.Interfaces.REST.Transform;

public class UpdateGarmentCommandFromResourceAssembler
{
    public static UpdateGarmentCommand ToCommandFromResource(UpdateGarmentResource resource, int garmentId)
    {
        return new UpdateGarmentCommand(garmentId, resource.size, resource.description,
            resource.material, resource.brand, resource.timesRented);
    }
}