using Microsoft.AspNetCore.Mvc;
using Style_Share_Platform.Rent.Domain.Model.Queries;
using Style_Share_Platform.Rent.Domain.Services;
using Style_Share_Platform.Rent.Interfaces.REST.Resource;
using Style_Share_Platform.Rent.Interfaces.REST.Transform;

namespace Style_Share_Platform.Rent.Interfaces.REST;

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
