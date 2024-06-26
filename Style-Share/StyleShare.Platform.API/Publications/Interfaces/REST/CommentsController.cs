using Microsoft.AspNetCore.Mvc;
using StyleShare.Platform.API.Publications.Domain.Model.Queries;
using StyleShare.Platform.API.Publications.Domain.Services;
using StyleShare.Platform.API.Publications.Interfaces.REST.Resources;
using StyleShare.Platform.API.Publications.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace StyleShare.Platform.API.Publications.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class CommentsController(ICommentCommandService commentCommandService, 
    ICommentQueryService commentQueryService) : ControllerBase
{

    [SwaggerOperation(Summary = "Get comment by id")]
    [HttpGet("{commentId}")]
    public async Task<IActionResult> GetCommentById([FromRoute] int commentId)
    {
        var comment = await commentQueryService.Handle(new GetCommentByIdQuery(commentId));
        if (comment is null) return NotFound();
        var resource = CommentResourceFromEntityAssembler.ToResourceFromEntity(comment);
        return Ok(resource);
    }

    [SwaggerOperation(Summary = "Get all comments")]
    [HttpGet]
    public async Task<IActionResult> GetAllComments()
    {
        var getAllComments = new GetAllCommentsQuery();
        var comments = await commentQueryService.Handle(getAllComments);
        var resources = comments.Select(CommentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [SwaggerOperation(Summary = "Create comment")]
    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CreateCommentResource createCommentResource)
    {
        var createCommentCommand =
            CreateCommentCommandFromResourceAssembler.ToCommandFromResource(createCommentResource);
        Console.WriteLine("Ready to ececute command" + createCommentCommand.ToString());
        var comment = await commentCommandService.Handle(createCommentCommand);
        if (comment is null) return BadRequest();
        var resource = CommentResourceFromEntityAssembler.ToResourceFromEntity(comment);
        return CreatedAtAction(nameof(GetCommentById), new { commentId = resource.Id }, resource);
    }

    [SwaggerOperation(Summary = "Update comment")]
    [HttpPut("{commentId}")]
    public async Task<IActionResult> UpdateComment(
        [FromBody] UpdateCommentResource updateCommentResource, [FromRoute] int commentId)
    {
        var updateCommentCommand = UpdateCommentCommandFromResourceAssembler
            .ToCommandFromResource(updateCommentResource, commentId);
        var comment = await commentCommandService.Handle(updateCommentCommand);
        var resource = CommentResourceFromEntityAssembler.ToResourceFromEntity(comment);
        return CreatedAtAction(nameof(GetCommentById), new{commentId = resource.Id}, resource);
    }
}