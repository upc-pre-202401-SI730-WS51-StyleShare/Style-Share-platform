namespace StyleShare.Platform.API.Rent.Interfaces.REST.Resource;

public record CartResource(
    int Id,
    int cuponDiscount, int quantityProducts, float subTotal
    )
{
    
}