using StyleShare.Platform.API.Shared.Domain.Repositories;
using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;

namespace StyleShare.Platform.API.Transactions.Domain.Repositories;

public interface ITransactionRepository : IBaseRepository<Transaction>
{
    
}