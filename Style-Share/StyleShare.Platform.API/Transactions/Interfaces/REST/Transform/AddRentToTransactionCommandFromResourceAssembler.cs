using StyleShare.Platform.API.Transactions.Domain.Model.Commands;
using StyleShare.Platform.API.Transactions.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Transactions.Interfaces.REST.Transform;

public class AddRentToTransactionCommandFromResourceAssembler
{
    public static AddRentToTransactionCommand ToCommandFromResource(AddRentToTransactionResource addRentToTransactionResource, int transactionId)
    {
        return new AddRentToTransactionCommand(addRentToTransactionResource.rentId, transactionId);
    }
}