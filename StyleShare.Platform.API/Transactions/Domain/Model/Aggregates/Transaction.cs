using StyleShare.Platform.API.Transactions.Domain.Model.Commands;
using StyleShare.Platform.API.Transactions.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;

public partial class Transaction
{
    public int Id { get; }
    public string Details {get; private set;}
    public int Amount {get; private set;}
    public EPaymentMethod PaymentMethod {get; private set;}
    public List<int> RentIds {get; private set;}
    
    public Transaction()
    {
        Details = string.Empty;
        Amount = 0;
        PaymentMethod = EPaymentMethod.None;
        RentIds = new List<int>();
    }
    
    public Transaction(string details, int amount, EPaymentMethod paymentMethod) : this()
    {
        Details = details;
        Amount = amount;
        PaymentMethod = paymentMethod;
    }

    public Transaction(CreateTransactionCommand command)
    {
        Details = command.details;
        Amount = command.amount;
        PaymentMethod = command.paymentMethod;
    }

    public void addRent(int rentId)
    {
        RentIds.Add(rentId);
    }
}