using Style_Share_Platform.Rent.Domain.Model.Entities;
using Style_Share_Platform.Rent.Domain.Model.Queries;

namespace Style_Share_Platform.Rent.Domain.Services;

public interface ICartQueryService
{
    Task<Cart?> Handle(GetCartByIdQuery query);
    Task<IEnumerable<Cart>> Handle(GetCartWithDiscount query);
    
    Task<IEnumerable<Cart>> Handle(GetAllCartsQuery query);

}