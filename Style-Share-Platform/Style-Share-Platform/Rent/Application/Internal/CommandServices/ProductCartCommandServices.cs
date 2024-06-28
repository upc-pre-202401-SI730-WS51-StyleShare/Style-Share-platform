using Style_Share_Platform.Rent.Domain.Model.Commands;
using Style_Share_Platform.Rent.Domain.Model.Entities;
using Style_Share_Platform.Rent.Domain.Repositories;
using Style_Share_Platform.Rent.Domain.Services;
using Style_Share_Platform.Shared.Domain.Repositories;

namespace Style_Share_Platform.Rent.Application.Internal.CommandServices;

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