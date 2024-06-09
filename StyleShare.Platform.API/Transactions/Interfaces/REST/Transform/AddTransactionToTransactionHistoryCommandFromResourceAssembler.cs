using StyleShare.Platform.API.Transactions.Domain.Model.Commands;
using StyleShare.Platform.API.Transactions.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Transactions.Interfaces.REST.Transform;

public class AddTransactionToTransactionHistoryCommandFromResourceAssembler
{
    public static AddTransactionToTransactionHistoryCommand ToCommandFromResource(
        AddTransactionToTransactionHistoryResource addTransactionToTransactionHistoryResource,
        int transactionHistoryId)
    {
        return new AddTransactionToTransactionHistoryCommand(addTransactionToTransactionHistoryResource.transactionId,
            transactionHistoryId);
    }
}