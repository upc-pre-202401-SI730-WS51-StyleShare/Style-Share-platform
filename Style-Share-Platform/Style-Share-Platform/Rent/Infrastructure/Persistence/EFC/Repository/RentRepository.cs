using Microsoft.EntityFrameworkCore;
using Style_Share_Platform.Rent.Domain.Repositories;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Style_Share_Platform.Rent.Infrastructure.Persistence.EFC.Repository;

public class RentRepository(AppDBContext context): BaseRepository<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>(context),
    IRentRepository
{
    public async Task<IEnumerable<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>> ListRent()
    {
        return await Context.Set<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>()
            .ToListAsync();
    }

    public async Task<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent?> FindByIdAsync(int id)
    {
        return await Context.Set<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>()
            .FirstOrDefaultAsync(rent => rent.Id == id);
    }
}