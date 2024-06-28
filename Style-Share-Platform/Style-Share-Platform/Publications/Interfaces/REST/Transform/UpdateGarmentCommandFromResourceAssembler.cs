using Style_Share_Platform.Publications.Domain.Model.Commands;
using Style_Share_Platform.Publications.Interfaces.REST.Resources;

namespace Style_Share_Platform.Publications.Interfaces.REST.Transform;

public class UpdateGarmentCommandFromResourceAssembler
{
    public static UpdateGarmentCommand ToCommandFromResource(UpdateGarmentResource resource, int garmentId)
    {
        return new UpdateGarmentCommand(garmentId, resource.size, resource.description,
            resource.material, resource.brand, resource.timesRented);
    }
}