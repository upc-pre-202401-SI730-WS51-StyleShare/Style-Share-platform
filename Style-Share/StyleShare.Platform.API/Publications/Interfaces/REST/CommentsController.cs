using Microsoft.AspNetCore.Mvc;
using StyleShare.Platform.API.Publications.Domain.Model.Queries;
using StyleShare.Platform.API.Publications.Domain.Services;
using StyleShare.Platform.API.Publications.Interfaces.REST.Resources;
using StyleShare.Platform.API.Publications.Interfaces.REST.Transform;

namespace StyleShare.Platform.API.Publications.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class CommentsController(ICommentCommandService commentCommandService, 
    ICommentQueryService commentQueryService) : ControllerBase
{

    [HttpGet("{commentId}")]
    public async Task<IActionResult> GetCommentById([FromRoute] int commentId)
    {
        var comment = await commentQueryService.Handle(new GetCommentByIdQuery(commentId));
        if (comment is null) return NotFound();
        var resource = CommentResourceFromEntityAssembler.ToResourceFromEntity(comment);
        return Ok(resource);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CreateCommentResource createCommentResource)
    {
        var createCommentCommand =
            CreateCommentCommandFromResourceAssembler.ToCommandFromResource(createCommentResource);
        Console.WriteLine("Ready to ececute command" + createCommentCommand.ToString());
        var comment = await commentCommandService.Handle(createCommentCommand);
        if (comment is null) return BadRequest();
        var resource = CommentResourceFromEntityAssembler.ToResourceFromEntity(comment);
        return CreatedAtAction(nameof(GetCommentById), new { comment = resource.Id }, resource);
    }

    [HttpPut("{commentId}")]
    public async Task<IActionResult> UpdateComment(
        [FromBody] UpdateCommentResource updateCommentResource, [FromRoute] int commentId)
    {
        var updateCommentCommand = UpdateCommentCommandFromResourceAssembler
            .ToCommandFromResource(updateCommentResource, commentId);
        var comment = await commentCommandService.Handle(updateCommentCommand);
        var resource = CommentResourceFromEntityAssembler.ToResourceFromEntity(comment);
        return CreatedAtAction(nameof(GetCommentById), new{commentIdentifier = resource.Id}, resource);
    }
}