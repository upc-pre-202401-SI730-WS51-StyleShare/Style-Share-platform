using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;
using StyleShare.Platform.API.Transactions.Domain.Model.Queries;

namespace StyleShare.Platform.API.Transactions.Domain.Services;

public interface ITransactionQueryService
{
    Task<Transaction?> Handle(GetTransactionByIdQuery query);
}