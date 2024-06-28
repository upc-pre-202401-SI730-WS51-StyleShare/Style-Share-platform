using StyleShare.Platform.API.Rent.Domain.Model.Commands;
using StyleShare.Platform.API.Rent.Interfaces.REST.Resource;

namespace StyleShare.Platform.API.Rent.Interfaces.REST.Transform;

public class CreateProductoToCartCommandFromResourceAssembler
{
    public static AddProductToCartCommand toCommandFromResource(CreateProductToCartResource createProductToCartResource)
    {
        return new AddProductToCartCommand(createProductToCartResource.productid, 
            createProductToCartResource.cartid);
    }
    
}
