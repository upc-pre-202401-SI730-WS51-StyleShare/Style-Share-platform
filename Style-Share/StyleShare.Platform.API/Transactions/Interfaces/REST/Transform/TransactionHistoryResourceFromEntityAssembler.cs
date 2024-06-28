using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;
using StyleShare.Platform.API.Transactions.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Transactions.Interfaces.REST.Transform;

public class TransactionHistoryResourceFromEntityAssembler
{
    public static TransactionHistoryResource ToResourceFromEntity(TransactionHistory transactionHistory)
    {
        return new TransactionHistoryResource(transactionHistory.Id, transactionHistory.TransactionIds);
    }
}