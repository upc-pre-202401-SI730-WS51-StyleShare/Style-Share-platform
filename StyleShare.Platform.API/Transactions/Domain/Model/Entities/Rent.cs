using StyleShare.Platform.API.Transactions.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Transactions.Domain.Model.Entities;

public partial class Rent
{
    public int Id { get; private set;}
    public UserId userId { get; private set;}
    public int amount { get; private set;}

    public Rent()
    {
        this.userId = new UserId(-1);
    }
    
    public Rent(int userId, int amount)
    {
        this.userId = new UserId(userId);
        this.amount = amount;
    }
}