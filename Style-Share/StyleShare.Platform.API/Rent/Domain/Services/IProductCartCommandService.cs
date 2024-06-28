using StyleShare.Platform.API.Rent.Domain.Model.Commands;
using StyleShare.Platform.API.Rent.Domain.Model.Entities;

namespace StyleShare.Platform.API.Rent.Domain.Services;

public interface IProductCartCommandService
{
    public Task<ProductCart> Handle(AddProductToCartCommand command);

}