using Style_Share_Platform.Rent.Domain.Model.ValueObjects;

namespace Style_Share_Platform.Rent.Domain.Model.Commands;

public record CreateRentCommand(int cartId, ShippingId shippingId, UserId userId,  DateRent rental_date); //string state,