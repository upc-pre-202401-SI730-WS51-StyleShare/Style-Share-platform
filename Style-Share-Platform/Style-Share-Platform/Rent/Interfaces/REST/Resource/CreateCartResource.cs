namespace Style_Share_Platform.Rent.Interfaces.REST.Resource;

public record CreateCartResource( 
    int cuponDiscount, 
    int quantityProducts, 
    float subTotal);