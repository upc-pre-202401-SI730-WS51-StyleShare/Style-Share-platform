using StyleShare.Platform.API.Rent.Domain.Model.Entities;
using StyleShare.Platform.API.Rent.Domain.Model.Queries;
using StyleShare.Platform.API.Rent.Domain.Repositories;
using StyleShare.Platform.API.Rent.Domain.Services;

namespace StyleShare.Platform.API.Rent.Application.Internal.QueryServices;

public class ProductCartQueryService(IProductCartRepository productCartRepository) : IProductCartQueryService
{
    public async Task<IEnumerable<ProductCart>> Handle(GetProducysByCartQuery query)
    {
        return await productCartRepository.FindProductsByCartId(query.cartId);
    }
}