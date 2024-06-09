using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;
using StyleShare.Platform.API.Transactions.Domain.Model.Queries;
using StyleShare.Platform.API.Transactions.Domain.Repositories;
using StyleShare.Platform.API.Transactions.Domain.Services;

namespace StyleShare.Platform.API.Transactions.Application.Internal.QueryServices;

public class TransactionQueryService(ITransactionRepository transactionRepository): ITransactionQueryService
{
    public async Task<Transaction?> Handle(GetTransactionByIdQuery query)
    {
        return await transactionRepository.FindByIdAsync(query.transactionId);
    }
}