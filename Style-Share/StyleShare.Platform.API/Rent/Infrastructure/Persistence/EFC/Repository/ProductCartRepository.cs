using Microsoft.EntityFrameworkCore;
using StyleShare.Platform.API.Rent.Domain.Model.Entities;
using StyleShare.Platform.API.Rent.Domain.Repositories;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace StyleShare.Platform.API.Rent.Infrastructure.Persistence.EFC.Repository;

public class ProductCartRepository(AppDBContext context): BaseRepository<ProductCart>(context),
    IProductCartRepository
{
    public async Task<IEnumerable<ProductCart>> ListProductCart()
    {
        return await Context.Set<ProductCart>()
            .ToListAsync();
    }
    
    public async Task<IEnumerable<ProductCart>> FindProductsByCartId(int cartid)
    {
        return await Context.Set<ProductCart>()
            .Where(productCart => productCart.CartId == cartid)
            .ToListAsync();
        
    }

}