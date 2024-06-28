using Style_Share_Platform.Rent.Domain.Model.Entities;
using Style_Share_Platform.Rent.Domain.Model.Queries;
using Style_Share_Platform.Rent.Domain.Repositories;
using Style_Share_Platform.Rent.Domain.Services;

namespace Style_Share_Platform.Rent.Application.Internal.QueryServices;

public class ProductCartQueryService(IProductCartRepository productCartRepository) : IProductCartQueryService
{
    public async Task<IEnumerable<ProductCart>> Handle(GetProducysByCartQuery query)
    {
        return await productCartRepository.FindProductsByCartId(query.cartId);
    }
    
    public async Task<IEnumerable<ProductCart>> Handle(GetAllProductsCart query)
    {
        return await productCartRepository.ListProductCart();
    }
}