using Style_Share_Platform.Publications.Domain.Model.Commands;
using Style_Share_Platform.Publications.Interfaces.REST.Resources;

namespace Style_Share_Platform.Publications.Interfaces.REST.Transform;

public class CreateGarmentCommandFromResourceAssembler
{
    public static CreateGarmentCommant ToCommandFromResource (CreateGarmentResource resource)
    {
        return new CreateGarmentCommant(resource.size, resource.description, resource.material, 
            resource.brand, resource.timesRented);
    }
}