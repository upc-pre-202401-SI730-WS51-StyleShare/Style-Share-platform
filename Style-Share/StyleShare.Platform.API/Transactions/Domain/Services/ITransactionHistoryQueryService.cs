using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;
using StyleShare.Platform.API.Transactions.Domain.Model.Queries;

namespace StyleShare.Platform.API.Transactions.Domain.Services;

public interface ITransactionHistoryQueryService
{
    Task<IEnumerable<TransactionHistory>> Handle(GetAllTransactionHistoriesQuery query);
    Task<TransactionHistory?> Handle(GetTransactionHistoryByIdQuery query);
}