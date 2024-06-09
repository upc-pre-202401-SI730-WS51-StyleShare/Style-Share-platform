using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;
using StyleShare.Platform.API.Transactions.Domain.Model.Queries;
using StyleShare.Platform.API.Transactions.Domain.Repositories;
using StyleShare.Platform.API.Transactions.Domain.Services;

namespace StyleShare.Platform.API.Transactions.Application.Internal.QueryServices;

public class TransactionHistoryQueryService(ITransactionHistoryRepository transactionHistoryRepository): ITransactionHistoryQueryService
{
    public async Task<IEnumerable<TransactionHistory>> Handle(GetAllTransactionHistoriesQuery query)
    {
        return await transactionHistoryRepository.ListAsync();
    }

    public async Task<TransactionHistory?> Handle(GetTransactionHistoryByIdQuery query)
    {
        return await transactionHistoryRepository.FindByIdAsync(query.transactionHistoryId);
    }
}