namespace StyleShare.Platform.API.Rent.Domain.Model.Aggregates;
using StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;

public class Rent
{
    public int Id { get; set; }
    public CartId CartId { get; private set; }
    public ShippingId ShippingId { get; private set; }
    public UserId UserId { get; private set; }
    public State State { get; private set; }
    public Date rentaldate { get; private set; }

    public Rent(CartId cartId, ShippingId shippingId, UserId userId, State state, Date rental_date) 
    {
        CartId = cartId;
        ShippingId = shippingId;
        UserId = userId;
        State = state;
        rentaldate=rental_date;
    }

}