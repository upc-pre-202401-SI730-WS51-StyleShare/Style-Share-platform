using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using StyleShare.Platform.API.PersonaUsers.Domain.Model.Queries;
using StyleShare.Platform.API.PersonaUsers.Domain.Services;
using StyleShare.Platform.API.PersonaUsers.Interfaces.REST.Resources;
using StyleShare.Platform.API.PersonaUsers.Interfaces.REST.Transform;

namespace StyleShare.Platform.API.PersonaUsers.Interfaces.REST;



[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UserController(IUsersCommandService usersCommandService, IUserQueryService userQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserResource resource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var user = await usersCommandService.Handle(createUserCommand);
        if (user is null) return BadRequest();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUserById), new {userId = userResource.Id}, userResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
    
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user == null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }
    
}
