using event_wear_platform.Shared.Domain.Repositories;
using event_wear_platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace event_wear_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDBContext _context;
    public UnitOfWork(AppDBContext context) => _context = context;

    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}