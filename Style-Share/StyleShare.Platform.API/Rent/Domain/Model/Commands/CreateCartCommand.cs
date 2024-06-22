namespace StyleShare.Platform.API.Rent.Domain.Model.Commands;

public record CreateCartCommand( int cuponDiscount, int quantityProducts, float subTotal){}