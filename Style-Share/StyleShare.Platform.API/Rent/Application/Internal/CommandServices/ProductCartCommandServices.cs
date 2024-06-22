using StyleShare.Platform.API.Rent.Domain.Model.Commands;
using StyleShare.Platform.API.Rent.Domain.Model.Entities;
using StyleShare.Platform.API.Rent.Domain.Repositories;
using StyleShare.Platform.API.Rent.Domain.Services;
using StyleShare.Platform.API.Shared.Domain.Repositories;

namespace StyleShare.Platform.API.Rent.Application.Internal.CommandServices;

public class ProductCartCommandServices(IProductCartRepository productCartRepository, 
    IUnitOfWork unitOfWork) : IProductCartCommandService
{
    public async Task<ProductCart> Handle(AddProductToCartCommand command){
        var productCart = new ProductCart(command.cartid, command.productid);
        await productCartRepository.AddAsync(productCart);
        await unitOfWork.CompleteAsync();
        return productCart;
    }
}