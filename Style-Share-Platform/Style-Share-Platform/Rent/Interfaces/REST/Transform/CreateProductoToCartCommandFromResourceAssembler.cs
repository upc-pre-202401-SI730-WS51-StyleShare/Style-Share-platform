using Style_Share_Platform.Rent.Domain.Model.Commands;
using Style_Share_Platform.Rent.Interfaces.REST.Resource;

namespace Style_Share_Platform.Rent.Interfaces.REST.Transform;

public class CreateProductoToCartCommandFromResourceAssembler
{
    public static AddProductToCartCommand toCommandFromResource(CreateProductToCartResource createProductToCartResource)
    {
        return new AddProductToCartCommand(createProductToCartResource.productid, 
            createProductToCartResource.cartid);
    }
    
}
