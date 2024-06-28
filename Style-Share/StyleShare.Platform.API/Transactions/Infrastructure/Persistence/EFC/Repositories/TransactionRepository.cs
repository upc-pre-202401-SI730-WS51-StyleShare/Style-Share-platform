using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;
using StyleShare.Platform.API.Transactions.Domain.Repositories;

namespace StyleShare.Platform.API.Transactions.Infrastructure.Persistence.EFC.Repositories;

public class TransactionRepository(AppDBContext context) : BaseRepository<Transaction>(context), ITransactionRepository
{
    
}