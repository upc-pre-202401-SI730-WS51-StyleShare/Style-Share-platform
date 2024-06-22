using StyleShare.Platform.API.Rent.Domain.Model.Commands;
using StyleShare.Platform.API.Rent.Interfaces.REST.Resource;

namespace StyleShare.Platform.API.Rent.Interfaces.REST.Transform;

public class CreateRentCommandFromResourceAssembler
{
    public static CreateRentCommand toCommandFromResource(CreateRentResource createRentResource)
    {
        return new CreateRentCommand(createRentResource.cartId, createRentResource.shippingId,
            createRentResource.userId, createRentResource.rental_date);


    }
}