using StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Rent.Domain.Model.Commands;

public record CreateRentCommand(int cartId, int shippingId, int userId, string state, string rental_date);