using StyleShare.Platform.API.Rent.Domain.Model.Commands;
using StyleShare.Platform.API.Rent.Domain.Model.Entities;
using StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;
using StyleShare.Platform.API.Rent.Domain.Repositories;
using StyleShare.Platform.API.Rent.Domain.Services;
using StyleShare.Platform.API.Rent.Infrastructure.Persistence.EFC.Repository;
using StyleShare.Platform.API.Shared.Domain.Repositories;

namespace StyleShare.Platform.API.Rent.Application.Internal.CommandServices;

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