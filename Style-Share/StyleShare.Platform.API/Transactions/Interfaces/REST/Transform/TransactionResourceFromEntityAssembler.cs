using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;
using StyleShare.Platform.API.Transactions.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Transactions.Interfaces.REST.Transform;

public class TransactionResourceFromEntityAssembler
{
    public static TransactionResource ToResourceFromEntity(Transaction transaction)
    {
        return new TransactionResource(
            transaction.Id,
            transaction.Details,
            transaction.Amount,
            transaction.PaymentMethod,
            transaction.RentIds);
    }
}