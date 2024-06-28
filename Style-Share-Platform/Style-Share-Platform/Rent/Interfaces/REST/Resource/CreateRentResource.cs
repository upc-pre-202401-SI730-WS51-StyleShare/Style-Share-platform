using Style_Share_Platform.Rent.Domain.Model.ValueObjects;

namespace Style_Share_Platform.Rent.Interfaces.REST.Resource;

public record CreateRentResource(
    int cartId, 
    ShippingId shippingId, 
    UserId userId, 
    DateRent rental_date
    
    );