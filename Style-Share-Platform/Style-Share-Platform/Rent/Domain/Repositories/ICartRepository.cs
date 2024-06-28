using Style_Share_Platform.Rent.Domain.Model.Entities;
using Style_Share_Platform.Shared.Domain.Repositories;

namespace Style_Share_Platform.Rent.Domain.Repositories;

public interface ICartRepository : IBaseRepository<Cart>
{
    Task<Cart> FindByIdAsync(int userId);
    
    Task<IEnumerable<Cart>> FindByDiscountAsync();
    
    Task<IEnumerable<Cart>> ListCart(); 

}