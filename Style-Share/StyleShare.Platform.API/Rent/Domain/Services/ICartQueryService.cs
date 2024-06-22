using StyleShare.Platform.API.Rent.Domain.Model.Entities;
using StyleShare.Platform.API.Rent.Domain.Model.Queries;

namespace StyleShare.Platform.API.Rent.Domain.Services;

public interface ICartQueryService
{
    Task<Cart?> Handle(GetCartByIdQuery query);
    Task<IEnumerable<Cart>> Handle(GetCartWithDiscount query);

}