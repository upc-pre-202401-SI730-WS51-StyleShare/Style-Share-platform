using StyleShare.Platform.API.Publications.Domain.Model.Commands;
using StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Publications.Interfaces.REST.Transform;

public class CreateGarmentCommandFromResourceAssembler
{
    public static CreateGarmentCommant ToCommandFromResource (CreateGarmentResource resource)
    {
        return new CreateGarmentCommant(resource.size, resource.description, resource.material, 
            resource.brand, resource.timesRented);
    }
}