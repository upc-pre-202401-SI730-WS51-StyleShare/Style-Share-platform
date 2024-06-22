using StyleShare.Platform.API.Rent.Interfaces.REST.Resource;

namespace StyleShare.Platform.API.Rent.Interfaces.REST.Transform;

public class RentResourceFromEntityAssembler
{
    public static RentResource toResourceFromEntity(Domain.Model.Aggregates.Rent rent)
    {
        return new RentResource(rent.Id, rent.CartId, rent.ShippingId, rent.UserId, rent.RentalDate);
    }
}