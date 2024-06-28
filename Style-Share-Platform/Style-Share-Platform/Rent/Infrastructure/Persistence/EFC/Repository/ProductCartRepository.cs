using Microsoft.EntityFrameworkCore;
using Style_Share_Platform.Rent.Domain.Model.Entities;
using Style_Share_Platform.Rent.Domain.Repositories;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Style_Share_Platform.Rent.Infrastructure.Persistence.EFC.Repository;

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