using StyleShare.Platform.API.Transactions.Domain.Model.Commands;
using StyleShare.Platform.API.Transactions.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Transactions.Interfaces.REST.Transform;

public class CreateTransactionCommandFromResourceAssembler
{
    public static CreateTransactionCommand ToCommandFromResource(CreateTransactionResource resource)
    {
        return new CreateTransactionCommand(resource.Details, resource.Amount, resource.PaymentMethod);
    }
}