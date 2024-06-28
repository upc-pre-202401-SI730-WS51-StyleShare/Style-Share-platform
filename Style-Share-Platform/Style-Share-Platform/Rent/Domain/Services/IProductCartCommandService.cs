using Style_Share_Platform.Rent.Domain.Model.Commands;
using Style_Share_Platform.Rent.Domain.Model.Entities;

namespace Style_Share_Platform.Rent.Domain.Services;

public interface IProductCartCommandService
{
    public Task<ProductCart> Handle(AddProductToCartCommand command);

}