using Style_Share_Platform.Rent.Domain.Model.Commands;
using Style_Share_Platform.Rent.Domain.Model.Entities;
using Style_Share_Platform.Rent.Domain.Model.ValueObjects;
using Style_Share_Platform.Rent.Domain.Repositories;
using Style_Share_Platform.Rent.Domain.Services;
using Style_Share_Platform.Shared.Domain.Repositories;

namespace Style_Share_Platform.Rent.Application.Internal.CommandServices;

public class CartCommandServices(ICartRepository cartRepository, 
    IUnitOfWork unitOfWork) : ICartCommandService
{
    
    public async Task<Cart> Handle(CreateCartCommand command){
        var cart = new Cart(command.cuponDiscount, command.quantityProducts, command.subTotal);
        await cartRepository.AddAsync(cart);
        await unitOfWork.CompleteAsync();
        return cart;
    }
    
    
    
    public async Task<Cart?> Handle(AddProductToCartCommand command)
    {
        var cart = await cartRepository.FindByIdAsync(command.cartid);
        if (cart == null)
        {
            cart = new Cart( 0, 0, 0.0f); //new List<ProductId>(),
            await cartRepository.AddAsync(cart);
        }
        var productId = new ProductId(command.productid);
        //cart.AddProduct(productId);
        await unitOfWork.CompleteAsync();
        return cart;
    }

    public async Task<Cart> Handle(DeleteProductToCartCommand command)
    {
        var cart = await cartRepository.FindByIdAsync(command.cartid);
        if (cart != null)
        {
            var productId = new ProductId(command.productid);
            //cart.RemoveProduct(productId);
            await unitOfWork.CompleteAsync();
        }
        return cart;
    }
    
}