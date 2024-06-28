using Style_Share_Platform.Rent.Domain.Model.Entities;
using Style_Share_Platform.Rent.Domain.Model.ValueObjects;

namespace Style_Share_Platform.Rent.Domain.Model.Aggregates
{
    public class Rent
    {
        public int Id { get; set; }
        public int CartId { get; private set; }
        public ShippingId ShippingId { get; private set; }
        public UserId UserId { get; private set; }
        public State state { get; private set; }
        public DateRent RentalDate { get; private set; }
        
        public Cart Cart { get; set; }

        public Rent() { }
        public Rent(int cartId, ShippingId shippingId, UserId userId, DateRent rental_date)
        {
            CartId = cartId;
            ShippingId = shippingId;
            UserId = userId;
            state = new State();
            RentalDate = rental_date;
        }
    }
}