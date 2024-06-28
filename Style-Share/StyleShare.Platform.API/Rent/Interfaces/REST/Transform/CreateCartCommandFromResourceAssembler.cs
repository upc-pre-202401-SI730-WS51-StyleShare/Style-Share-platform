using StyleShare.Platform.API.Rent.Domain.Model.Commands;
using StyleShare.Platform.API.Rent.Interfaces.REST.Resource;

namespace StyleShare.Platform.API.Rent.Interfaces.REST.Transform;

public class CreateCartCommandFromResourceAssembler
{
   public static CreateCartCommand toCommandFromResource(CreateCartResource createCartResource)
   {
       return new CreateCartCommand(createCartResource.cuponDiscount, 
           createCartResource.quantityProducts, 
           createCartResource.subTotal);
   }
}