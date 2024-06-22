using System.Collections;
using StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Rent.Domain.Model.Entities;

public class Cart
{
    public int Id { get; set; }
    public ICollection<ProductCart> ProductCarts { get; set; }
    public int CuponDiscount { get; private set; }
    public int QuantityProducts { get; private set; }
    public float SubTotal { get; private set; }
    
    public Aggregates.Rent Rent { get; private set; }


    public Cart(){}
    public Cart( int cuponDiscount, int quantityProducts, float subTotal) //ICollection<ProductId> productIds
    {
        //ProductIds =  new List<ProductId>(productIds);
        CuponDiscount = cuponDiscount;
        QuantityProducts = quantityProducts;
        SubTotal = subTotal;
    }

    /*
    public void AddProduct(ProductId productId)
    {
        ProductIds.Add(productId);
    }
    public void RemoveProduct(ProductId productId)
    {
        ProductIds.Remove(productId);
    }
    */
}