using Microsoft.AspNetCore.Mvc;
using StyleShare.Platform.API.Rent.Domain.Model.Queries;
using StyleShare.Platform.API.Rent.Domain.Services;
using StyleShare.Platform.API.Rent.Interfaces.REST.Resource;
using StyleShare.Platform.API.Rent.Interfaces.REST.Transform;

namespace StyleShare.Platform.API.Rent.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class CartsController(
    ICartCommandService cartCommandService,
    ICartQueryService cartQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCart([FromBody] CreateCartResource createCartResource)
    {
        var createCartCommand = 
            CreateCartCommandFromResourceAssembler
                .toCommandFromResource(createCartResource);
        var cart = await cartCommandService.Handle(createCartCommand);
        if (cart is null) return BadRequest();
        var resource = CartResourceFromEntityAssembler.toResourceFromEntity(cart);
        return Created("", resource);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCartsById([FromRoute] int id)
    {
        var cart = await cartQueryService.Handle(new GetCartByIdQuery(id));
        if (cart is null) return NotFound();
        var resource = CartResourceFromEntityAssembler.toResourceFromEntity(cart);
        return Ok(resource);
    }
    
    
    
    
    [HttpGet("Discounted")]
    public async Task<IActionResult> GetCartsWithDiscount()
    {
        var carts = await cartQueryService.Handle(new GetCartWithDiscount());
        var resources = carts.Select(CartResourceFromEntityAssembler.toResourceFromEntity);
        return Ok(resources);
    }
}