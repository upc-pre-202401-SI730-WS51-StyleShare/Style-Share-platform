using Microsoft.EntityFrameworkCore;
using StyleShare.Platform.API.Rent.Domain.Repositories;
using StyleShare.Platform.API.Rent.Domain.Model.Aggregates;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace StyleShare.Platform.API.Rent.Infrastructure.Persistence.EFC.Repository;

public class RentRepository(AppDBContext context): BaseRepository<Domain.Model.Aggregates.Rent>(context),
    IRentRepository
{
    public async Task<IEnumerable<Domain.Model.Aggregates.Rent>> ListRent()
    {
        return await Context.Set<Domain.Model.Aggregates.Rent>()
            .ToListAsync();
    }

    public async Task<Domain.Model.Aggregates.Rent?> FindByIdAsync(int id)
    {
        return await Context.Set<Domain.Model.Aggregates.Rent>()
            .FirstOrDefaultAsync(rent => rent.Id == id);
    }
}