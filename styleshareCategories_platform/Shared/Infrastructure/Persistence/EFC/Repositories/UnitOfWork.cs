using styleshareCategories_platform.Shared.Domain.Repositories;
using styleshareCategories_platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace styleshareCategories_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDBContext _context;
    public UnitOfWork(AppDBContext context) => _context = context;

    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}