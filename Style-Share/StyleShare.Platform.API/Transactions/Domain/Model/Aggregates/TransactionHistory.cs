using StyleShare.Platform.API.Transactions.Domain.Model.Commands;
using StyleShare.Platform.API.Transactions.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;

public partial class TransactionHistory
{
    public int Id { get; }
    public List<int> TransactionIds {get; private set;}
    public List<TransactionId> TransactionIdsReference {get; private set;}

    public TransactionHistory()
    {
        TransactionIds = new List<int>();
        TransactionIdsReference = new List<TransactionId>();
    }
    
    public TransactionHistory(int transactionId)
    {
        TransactionIds = new List<int>();
        TransactionIdsReference = new List<TransactionId>();
        addTransaction(transactionId);
    }

    public TransactionHistory(CreateTransactionHistoryCommand command)
    {
        TransactionIds = new List<int>();
        TransactionIdsReference = new List<TransactionId>();
        addTransaction(command.transactionId);
    }
    
    public void addTransaction(int transactionId)
    {
        TransactionIds.Add(transactionId);
        TransactionIdsReference.Add(new TransactionId(transactionId));
    }
}