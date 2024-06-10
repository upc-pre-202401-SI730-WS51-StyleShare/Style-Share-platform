using Microsoft.EntityFrameworkCore;
using StyleShare.Platform.API.Rent.Domain.Model.Entities;
using StyleShare.Platform.API.Rent.Domain.Repositories;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace StyleShare.Platform.API.Rent.Infrastructure.Persistence.EFC.Repository;

public class CartRepository(AppDBContext context): BaseRepository<Cart>(context),
    ICartRepository
{
    public async Task<Cart?> FindByIdAsync(int cardid)
    {
        return await Context.Set<Cart>()
            .FirstOrDefaultAsync(cart => cart.Id == cardid);
    }

    public async Task<IEnumerable<Cart>> FindByDiscountAsync(int discount)
    {
        return await Context.Set<Cart>()
            .Where(cart => cart.CuponDiscount == discount)
            .ToListAsync();
    }

}

