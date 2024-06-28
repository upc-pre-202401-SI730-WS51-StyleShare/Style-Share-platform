using Microsoft.AspNetCore.Mvc;
using StyleShare.Platform.API.Rent.Application.Internal.QueryServices;
using StyleShare.Platform.API.Rent.Domain.Model.Queries;
using StyleShare.Platform.API.Rent.Domain.Services;
using StyleShare.Platform.API.Rent.Interfaces.REST.Resource;
using StyleShare.Platform.API.Rent.Interfaces.REST.Transform;

namespace StyleShare.Platform.API.Rent.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsCartController(
    IProductCartCommandService productCartCommandService,
    IProductCartQueryService productCartQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProductCart([FromBody] CreateProductToCartResource productCartResource)
    {
        var addProductCartCommand = 
            CreateProductoToCartCommandFromResourceAssembler
                .toCommandFromResource(productCartResource);
        var productCart = await productCartCommandService.Handle(addProductCartCommand);
        if (productCart == null) return BadRequest();
        var resource = ProductCartResourceFromEntity.toResourceFromEntity(productCart);
        return Created("", resource);    
    }
    
    [HttpGet("{CartId}")]
    public async Task<IActionResult> GetProductByCartId([FromRoute]int CartId)
    {
        var productCarts = await productCartQueryService.Handle(new GetProducysByCartQuery(CartId));
        var resource = productCarts.Select(ProductCartResourceFromEntity.toResourceFromEntity);
        return Ok(resource);
        
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllProductCarts()
    {
        var getAllProductCarts = new GetAllProductsCart();
        var productCarts = await productCartQueryService.Handle(getAllProductCarts);
        var resources = productCarts.Select(ProductCartResourceFromEntity.toResourceFromEntity);
        return Ok(resources);
    }

}