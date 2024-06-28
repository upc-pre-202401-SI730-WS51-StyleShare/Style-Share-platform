using Style_Share_Platform.Rent.Domain.Model.Commands;
using Style_Share_Platform.Rent.Domain.Model.Entities;

namespace Style_Share_Platform.Rent.Domain.Services;

public interface ICartCommandService
{
    public Task<Cart> Handle(CreateCartCommand command);
    
    public Task<Cart> Handle(AddProductToCartCommand command);
    public Task<Cart> Handle(DeleteProductToCartCommand command);
    
}