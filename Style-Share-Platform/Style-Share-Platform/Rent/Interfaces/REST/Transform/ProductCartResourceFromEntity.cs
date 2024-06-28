using Style_Share_Platform.Rent.Domain.Model.Entities;
using Style_Share_Platform.Rent.Interfaces.REST.Resource;

namespace Style_Share_Platform.Rent.Interfaces.REST.Transform;

public class ProductCartResourceFromEntity
{
    public static ProductCartResource toResourceFromEntity(ProductCart productCart)
    {
        return new ProductCartResource(productCart.Id, productCart.ProductId, productCart.CartId);
    }
}