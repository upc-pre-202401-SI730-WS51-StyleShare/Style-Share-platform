using StyleShare.Platform.API.Transactions.Domain.Model.Commands;
using StyleShare.Platform.API.Transactions.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;

public partial class Transaction
{
    public int Id { get; }
    public string Details {get; private set;}
    public int amount {get; private set;}
    public EPaymentMethod PaymentMethod {get; private set;}
    public List<int> RentIds {get; private set;}
    
    public Transaction()
    {
        Details = string.Empty;
        amount = 0;
        PaymentMethod = EPaymentMethod.None;
        RentIds = new List<int>();
    }
    
    public Transaction(string details, int amount, EPaymentMethod paymentMethod) : this()
    {
        Details = details;
        this.amount = amount;
        PaymentMethod = paymentMethod;
    }

    public Transaction(CreateTransactionCommand command)
    {
        
    }

    public void addRent(int rentId)
    {
        RentIds.Add(rentId);
    }
}