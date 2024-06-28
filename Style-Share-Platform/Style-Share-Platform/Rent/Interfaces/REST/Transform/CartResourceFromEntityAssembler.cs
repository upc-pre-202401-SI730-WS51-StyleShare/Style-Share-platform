using Style_Share_Platform.Rent.Domain.Model.Entities;
using Style_Share_Platform.Rent.Interfaces.REST.Resource;

namespace Style_Share_Platform.Rent.Interfaces.REST.Transform;

public class CartResourceFromEntityAssembler
{
    public static CartResource toResourceFromEntity(Cart cart)
    {
        return new CartResource(cart.Id, cart.CuponDiscount, cart.QuantityProducts, cart.SubTotal);
    }
}