using Microsoft.AspNetCore.Mvc;
using StyleShare.Platform.API.Rent.Domain.Model.Queries;
using StyleShare.Platform.API.Rent.Domain.Services;
using StyleShare.Platform.API.Rent.Interfaces.REST.Resource;
using StyleShare.Platform.API.Rent.Interfaces.REST.Transform;

namespace StyleShare.Platform.API.Rent.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class RentsController(
    IRentCommandService rentCommandService,
    IRentQueryService rentQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRent([FromBody] CreateRentResource createRentResource)
    {
        var createRentCommand = 
            CreateRentCommandFromResourceAssembler
                .toCommandFromResource(createRentResource);
        var rent = await rentCommandService.Handle(createRentCommand);
        if (rent is null) return BadRequest();
        var resource = RentResourceFromEntityAssembler.toResourceFromEntity(rent);
        return Created("", resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllRents()
    {
        var getAllRents = new GetAllRentsQuery();
        var rents = await rentQueryService.Handle(getAllRents);
        var resources = rents.Select(RentResourceFromEntityAssembler.toResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRentById([FromRoute]int id)
    {
        var rent = await rentQueryService.Handle(new GetRentByIdQuery(id));
        if (rent == null) return NotFound();
        var resource = RentResourceFromEntityAssembler.toResourceFromEntity(rent);
        return Ok(resource);
    }
    
}
