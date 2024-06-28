using Style_Share_Platform.Publications.Interfaces.REST.Resources;
using Garment = Style_Share_Platform.Publications.Domain.Model.Entities.Garment;

namespace Style_Share_Platform.Publications.Interfaces.REST.Transform;

public class GarmentResourceFromEntityAssembler
{
    public static GarmentResource ToResourceFromEntity(Garment garment)
    {
        return new GarmentResource(garment.Id, garment.Size, garment.Description,
            garment.Material, garment.Brand, garment.TimesRented);
    }
}