using Style_Share_Platform.Rent.Domain.Model.Entities;
using Style_Share_Platform.Rent.Domain.Model.Queries;

namespace Style_Share_Platform.Rent.Domain.Services;

public interface IProductCartQueryService
{
    Task<IEnumerable<ProductCart>> Handle(GetProducysByCartQuery query);
    
    Task<IEnumerable<ProductCart>> Handle(GetAllProductsCart query);

}