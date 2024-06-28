using Style_Share_Platform.Rent.Domain.Model.Entities;
using Style_Share_Platform.Rent.Domain.Model.Queries;
using Style_Share_Platform.Rent.Domain.Repositories;
using Style_Share_Platform.Rent.Domain.Services;

namespace Style_Share_Platform.Rent.Application.Internal.QueryServices;

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
