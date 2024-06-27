using Microsoft.EntityFrameworkCore;
using styleshareCategories_platform.Shared.Domain.Repositories;
using styleshareCategories_platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace styleshareCategories_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDBContext Context;

    protected BaseRepository(AppDBContext context) => Context = context;
    
    // Register / Add / POST
    public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);
    
    //Update 
    public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);
    
    //Delete
    public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);
    
    //Select / Get
    
    //Get one or zero record
    public async Task<TEntity?> FindByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);
    
    //Get many records
    public async Task<IEnumerable<TEntity>> ListAsync() => await Context.Set<TEntity>().ToListAsync();
}