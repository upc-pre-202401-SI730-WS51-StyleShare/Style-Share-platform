namespace StyleShare.Platform.API.Rent.Domain.Model.Commands;

public record DeleteProductToCartCommand(int productid, int cartid);