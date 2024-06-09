using StyleShare.Platform.API.Transactions.Domain.Model.Commands;

namespace StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;

public partial class TransactionHistory
{
    public int Id { get; }
    public List<int> TransactionIds {get; private set;}

    public TransactionHistory()
    {
        TransactionIds = new List<int>();
    }
    
    public TransactionHistory(int transactionId)
    {
        TransactionIds = new List<int>();
        addTransaction(transactionId);
    }

    public TransactionHistory(CreateTransactionHistoryCommand command)
    {
        TransactionIds = new List<int>();
        addTransaction(command.transactionId);
    }
    
    public void addTransaction(int transactionId)
    {
        TransactionIds.Add(transactionId);
    }
}