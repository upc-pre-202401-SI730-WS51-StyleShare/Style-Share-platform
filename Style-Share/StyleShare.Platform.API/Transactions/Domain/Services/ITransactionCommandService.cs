using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;
using StyleShare.Platform.API.Transactions.Domain.Model.Commands;

namespace StyleShare.Platform.API.Transactions.Domain.Services;

public interface ITransactionCommandService
{
    Task<Transaction> Handle(CreateTransactionCommand command);
    Task<Transaction> Handle(AddRentToTransactionCommand command);
}