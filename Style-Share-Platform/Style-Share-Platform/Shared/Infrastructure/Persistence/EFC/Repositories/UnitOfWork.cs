using Style_Share_Platform.Shared.Domain.Repositories;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDBContext _context;
    public UnitOfWork(AppDBContext context) => _context = context;

    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}