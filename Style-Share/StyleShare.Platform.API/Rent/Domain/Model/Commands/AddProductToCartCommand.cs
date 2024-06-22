using StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Rent.Domain.Model.Commands;

public record AddProductToCartCommand(int productid, int cartid )
{

}