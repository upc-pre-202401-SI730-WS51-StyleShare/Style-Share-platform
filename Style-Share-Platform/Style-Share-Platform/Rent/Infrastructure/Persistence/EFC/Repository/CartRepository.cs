using Microsoft.EntityFrameworkCore;
using Style_Share_Platform.Rent.Domain.Model.Entities;
using Style_Share_Platform.Rent.Domain.Repositories;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Style_Share_Platform.Rent.Infrastructure.Persistence.EFC.Repository;

public class CartRepository(AppDBContext context): BaseRepository<Cart>(context), ICartRepository
{
    
    public async Task<IEnumerable<Cart>> ListCart()
    {
        return await Context.Set<Cart>()
            .ToListAsync();
    }
    public async Task<Cart?> FindByIdAsync(int cardid)
    {
        return await Context.Set<Cart>()
            .FirstOrDefaultAsync(cart => cart.Id == cardid);
    }

    public async Task<IEnumerable<Cart>> FindByDiscountAsync()
    {
        return await Context.Set<Cart>()
            .Where(cart => cart.CuponDiscount != 0 )
            .ToListAsync();
    }
    
}

