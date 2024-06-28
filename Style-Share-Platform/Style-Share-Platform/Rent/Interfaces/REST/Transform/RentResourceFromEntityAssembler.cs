using Style_Share_Platform.Rent.Interfaces.REST.Resource;

namespace Style_Share_Platform.Rent.Interfaces.REST.Transform;

public class RentResourceFromEntityAssembler
{
    public static RentResource toResourceFromEntity(Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent rent)
    {
        return new RentResource(rent.Id, rent.CartId, rent.ShippingId, rent.UserId, rent.RentalDate);
    }
}