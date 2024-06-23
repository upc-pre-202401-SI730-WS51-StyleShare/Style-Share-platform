using StyleShare.Platform.API.Publications.Domain.Model.Entities;
using StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Publications.Interfaces.REST.Transform;

public class GarmentResourceFromEntityAssembler
{
    public static GarmentResource ToResourceFromEntity(Garment garment)
    {
        return new GarmentResource(garment.Id, garment.Size, garment.Description,
            garment.Material, garment.Brand, garment.TimesRented);
    }
}