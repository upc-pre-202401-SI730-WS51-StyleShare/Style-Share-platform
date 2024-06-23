using StyleShare.Platform.API.Transactions.Domain.Model.Commands;
using StyleShare.Platform.API.Transactions.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Transactions.Interfaces.REST.Transform;

public class CreateTransactionHistoryCommandFromResourceAssembler
{
    public static CreateTransactionHistoryCommand ToCommandFromResource(CreateTransactionHistoryResource resource)
    {
        return new CreateTransactionHistoryCommand(resource.transactionId);
    }
}