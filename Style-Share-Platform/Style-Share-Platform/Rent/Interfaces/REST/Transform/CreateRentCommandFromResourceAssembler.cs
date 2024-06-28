using Style_Share_Platform.Rent.Domain.Model.Commands;
using Style_Share_Platform.Rent.Interfaces.REST.Resource;

namespace Style_Share_Platform.Rent.Interfaces.REST.Transform;

public class CreateRentCommandFromResourceAssembler
{
    public static CreateRentCommand toCommandFromResource(CreateRentResource createRentResource)
    {
        return new CreateRentCommand(createRentResource.cartId, createRentResource.shippingId,
            createRentResource.userId, createRentResource.rental_date);


    }
}