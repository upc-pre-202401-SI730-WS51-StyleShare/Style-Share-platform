using StyleShare.Platform.API.Rent.Domain.Model.Entities;
using StyleShare.Platform.API.Shared.Domain.Repositories;

namespace StyleShare.Platform.API.Rent.Domain.Repositories;

public interface IProductCartRepository : IBaseRepository<ProductCart>
{
    Task<IEnumerable<ProductCart>> FindProductsByCartId(int cartid);

}