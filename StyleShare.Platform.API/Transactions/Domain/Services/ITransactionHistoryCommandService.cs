using System.Reflection.Metadata;
using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;
using StyleShare.Platform.API.Transactions.Domain.Model.Commands;

namespace StyleShare.Platform.API.Transactions.Domain.Services;

public interface ITransactionHistoryCommandService
{
    Task<TransactionHistory> Handle(CreateTransactionHistoryCommand command);
    Task<TransactionHistory> Handle(AddTransactionToTransactionHistoryCommand command);
}