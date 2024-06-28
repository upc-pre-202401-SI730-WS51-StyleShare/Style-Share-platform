using Style_Share_Platform.Rent.Domain.Model.Commands;
using Style_Share_Platform.Rent.Interfaces.REST.Resource;

namespace Style_Share_Platform.Rent.Interfaces.REST.Transform;

public class CreateCartCommandFromResourceAssembler
{
   public static CreateCartCommand toCommandFromResource(CreateCartResource createCartResource)
   {
       return new CreateCartCommand(createCartResource.cuponDiscount, 
           createCartResource.quantityProducts, 
           createCartResource.subTotal);
   }
}