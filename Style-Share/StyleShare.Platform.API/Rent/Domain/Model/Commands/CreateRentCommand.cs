using StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Rent.Domain.Model.Commands;

public record CreateRentCommand(int cartId, ShippingId shippingId, UserId userId,  DateRent rental_date); //string state,