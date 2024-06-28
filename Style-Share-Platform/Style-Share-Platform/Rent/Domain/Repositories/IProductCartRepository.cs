using Style_Share_Platform.Rent.Domain.Model.Entities;
using Style_Share_Platform.Shared.Domain.Repositories;

namespace Style_Share_Platform.Rent.Domain.Repositories;

public interface IProductCartRepository : IBaseRepository<ProductCart>
{
    Task<IEnumerable<ProductCart>> FindProductsByCartId(int cartid);

    Task<IEnumerable<ProductCart>> ListProductCart(); 

}