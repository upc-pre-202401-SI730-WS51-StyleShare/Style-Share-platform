using Microsoft.AspNetCore.Mvc;
using Style_Share_Platform.Rent.Domain.Model.Queries;
using Style_Share_Platform.Rent.Domain.Services;
using Style_Share_Platform.Rent.Interfaces.REST.Resource;
using Style_Share_Platform.Rent.Interfaces.REST.Transform;

namespace Style_Share_Platform.Rent.Interfaces.REST;

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
    
    
    [HttpGet]
    public async Task<IActionResult> GetAllCarts()
    {
        var getAllCarts = new GetAllCartsQuery();
        var carts = await cartQueryService.Handle(getAllCarts);
        var resources = carts.Select(CartResourceFromEntityAssembler.toResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("Discounted")]
    public async Task<IActionResult> GetCartsWithDiscount()
    {
        var carts = await cartQueryService.Handle(new GetCartWithDiscount());
        var resources = carts.Select(CartResourceFromEntityAssembler.toResourceFromEntity);
        return Ok(resources);
    }
}