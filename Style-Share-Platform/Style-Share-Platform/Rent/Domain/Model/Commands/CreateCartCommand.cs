namespace Style_Share_Platform.Rent.Domain.Model.Commands;

public record CreateCartCommand( int cuponDiscount, int quantityProducts, float subTotal){}