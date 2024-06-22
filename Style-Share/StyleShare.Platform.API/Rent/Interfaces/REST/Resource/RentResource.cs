using StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Rent.Interfaces.REST.Resource;

public record RentResource(
    int Id,
    int cartId, 
    ShippingId shippingId, 
    UserId userId, 
    DateRent rental_date
    );