using System.Collections;
using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;
using StyleShare.Platform.API.Transactions.Domain.Model.Queries;

namespace StyleShare.Platform.API.Transactions.Domain.Services;

public interface ITransactionQueryService
{
    Task<IEnumerable<Transaction>> Handle(GetAllTransactionsQuery query);
    Task<Transaction?> Handle(GetTransactionByIdQuery query);
}