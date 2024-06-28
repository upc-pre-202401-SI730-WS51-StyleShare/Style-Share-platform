using StyleShare.Platform.API.Rent.Domain.Model.Commands;
using StyleShare.Platform.API.Rent.Domain.Model.Entities;

namespace StyleShare.Platform.API.Rent.Domain.Services;

public interface ICartCommandService
{
    public Task<Cart> Handle(CreateCartCommand command);
    
    public Task<Cart> Handle(AddProductToCartCommand command);
    public Task<Cart> Handle(DeleteProductToCartCommand command);
    
}