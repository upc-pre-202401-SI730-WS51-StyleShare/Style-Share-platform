namespace StyleShare.Platform.API.Rent.Interfaces.REST.Resource;

public record CreateCartResource( 
    int cuponDiscount, 
    int quantityProducts, 
    float subTotal);