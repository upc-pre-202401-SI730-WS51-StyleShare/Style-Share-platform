using StyleShare.Platform.API.Rent.Domain.Model.Entities;
using StyleShare.Platform.API.Rent.Interfaces.REST.Resource;

namespace StyleShare.Platform.API.Rent.Interfaces.REST.Transform;

public class ProductCartResourceFromEntity
{
    public static ProductCartResource toResourceFromEntity(ProductCart productCart)
    {
        return new ProductCartResource(productCart.Id, productCart.ProductId, productCart.CartId);
    }
}