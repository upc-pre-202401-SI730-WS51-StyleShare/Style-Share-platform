using StyleShare.Platform.API.Rent.Domain.Model.Entities;
using StyleShare.Platform.API.Shared.Domain.Repositories;

namespace StyleShare.Platform.API.Rent.Domain.Repositories;

public interface ICartRepository : IBaseRepository<Cart>
{
    Task<Cart> FindByIdAsync(int userId);
    
    Task<IEnumerable<Cart>> FindByDiscountAsync();
}