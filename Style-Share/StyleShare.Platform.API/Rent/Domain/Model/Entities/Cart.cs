using StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Rent.Domain.Model.Entities;

public class Cart
{
    public int Id { get; set; }
    public List<ProductId> ProductIds { get; private set; }
    public int CuponDiscount { get; private set; }
    public int QuantityProducts { get; private set; }
    public float SubTotal { get; private set; }

    public Cart(List<ProductId> productIds, int cuponDiscount, int quantityProducts, float subTotal)
    {
        ProductIds = productIds ?? new List<ProductId>();
        CuponDiscount = cuponDiscount;
        QuantityProducts = quantityProducts;
        SubTotal = subTotal;
    }

    public void AddProduct(ProductId productId)
    {
        ProductIds.Add(productId);
    }

    public void RemoveProduct(ProductId productId)
    {
        ProductIds.Remove(productId);
    }
}