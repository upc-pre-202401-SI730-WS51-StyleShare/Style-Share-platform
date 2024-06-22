using StyleShare.Platform.API.Rent.Domain.Model.Entities;
using StyleShare.Platform.API.Rent.Interfaces.REST.Resource;

namespace StyleShare.Platform.API.Rent.Interfaces.REST.Transform;

public class CartResourceFromEntityAssembler
{
    public static CartResource toResourceFromEntity(Cart cart)
    {
        return new CartResource(cart.Id, cart.CuponDiscount, cart.QuantityProducts, cart.SubTotal);
    }
}