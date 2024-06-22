using StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Rent.Domain.Model.Entities;

public class ProductCart
{
    public int Id { get; set; } 
    public int CartId { get; private set; }
    public int ProductId { get; private set; }

    public ProductCart(int cartId, int productId)
    {
        CartId = cartId;
        ProductId = productId;
    }
}

