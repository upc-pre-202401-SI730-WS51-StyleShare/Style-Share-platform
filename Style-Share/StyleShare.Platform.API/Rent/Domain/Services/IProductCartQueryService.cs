using StyleShare.Platform.API.Rent.Domain.Model.Entities;
using StyleShare.Platform.API.Rent.Domain.Model.Queries;

namespace StyleShare.Platform.API.Rent.Domain.Services;

public interface IProductCartQueryService
{
    Task<IEnumerable<ProductCart>> Handle(GetProducysByCartQuery query);
    
    Task<IEnumerable<ProductCart>> Handle(GetAllProductsCart query);

}