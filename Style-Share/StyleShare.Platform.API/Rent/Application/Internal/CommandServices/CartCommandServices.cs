using StyleShare.Platform.API.Rent.Domain.Model.Commands;
using StyleShare.Platform.API.Rent.Domain.Model.Entities;
using StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;
using StyleShare.Platform.API.Rent.Domain.Repositories;
using StyleShare.Platform.API.Rent.Domain.Services;
using StyleShare.Platform.API.Rent.Infrastructure.Persistence.EFC.Repository;
using StyleShare.Platform.API.Shared.Domain.Repositories;

namespace StyleShare.Platform.API.Rent.Application.Internal.CommandServices;

public class CartCommandServices : ICartCommandService
{
    private readonly ICartRepository _cartRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CartCommandServices(ICartRepository cartRepository, IUnitOfWork unitOfWork)
    {
        _cartRepository = cartRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Cart?> Handle(AddProductToCartCommand command)
    {
        var cart = await _cartRepository.FindByIdAsync(command.cartid);
        if (cart == null)
        {
            cart = new Cart(new List<ProductId>(), 0, 0, 0.0f);
            await _cartRepository.AddAsync(cart);
        }
        var productId = new ProductId(command.productid);
        cart.AddProduct(productId);
        await _unitOfWork.CompleteAsync();
        return cart;
    }

    public async Task<Cart> Handle(DeleteProductToCartCommand command)
    {
        var cart = await _cartRepository.FindByIdAsync(command.cartid);
        if (cart != null)
        {
            var productId = new ProductId(command.productid);
            cart.RemoveProduct(productId);
            await _unitOfWork.CompleteAsync();
        }
        return cart;
    }

}