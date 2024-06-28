using StyleShare.Platform.API.Rent.Domain.Model.Entities;
using StyleShare.Platform.API.Rent.Domain.Model.Queries;
using StyleShare.Platform.API.Rent.Domain.Repositories;
using StyleShare.Platform.API.Rent.Domain.Services;

namespace StyleShare.Platform.API.Rent.Application.Internal.QueryServices;

public class CartQueryService(ICartRepository cartRepository) :ICartQueryService
{
    public async Task<Cart?> Handle(GetCartByIdQuery query)
    {
        return await cartRepository.FindByIdAsync(query.cartId);
    }
    
    public async Task<IEnumerable<Cart>> Handle(GetCartWithDiscount query)
    {
        return await cartRepository.FindByDiscountAsync();
    }
    
    public async Task<IEnumerable<Cart>> Handle(GetAllCartsQuery query)
    {
        return await cartRepository.ListCart();
    }

}    
