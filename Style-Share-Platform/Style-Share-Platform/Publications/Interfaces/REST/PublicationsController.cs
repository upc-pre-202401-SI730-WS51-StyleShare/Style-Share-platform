using Microsoft.AspNetCore.Mvc;
using Style_Share_Platform.Publications.Domain.Model.Queries;
using Style_Share_Platform.Publications.Domain.Services;
using Style_Share_Platform.Publications.Interfaces.REST.Resources;
using Style_Share_Platform.Publications.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace Style_Share_Platform.Publications.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class PublicationsController(IPublicationCommandService publicationCommandService,
    IPublicationQueryService publicationQueryService) : ControllerBase
{

    [SwaggerOperation(Summary = "Get publication by id")]
    [HttpGet("{publicationId}")]
    public async Task<IActionResult> GetPublicationById([FromRoute] int publicationId)
    {
        var publication = await publicationQueryService.Handle(new GetPublicationByIdQuery(publicationId));
        if (publication is null) return NotFound();
        var resource = PublicationResourceFromEntityAssembler.ToResourceFromEntity(publication);
        return Ok(resource);
    }

    [SwaggerOperation(Summary = "Get all publications")]
    [HttpGet]
    public async Task<IActionResult> GetAllPublications()
    {
        var getAllPublicationsQuery = new GetAllPublicationsQuery();
        var publications = await publicationQueryService.Handle(getAllPublicationsQuery);
        var resources = publications.Select(PublicationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [SwaggerOperation(Summary = "Create publication")]
    [HttpPost]
    public async Task<IActionResult> CreatePublication([FromBody] CreatePublicationResource createPublicationResource)
    {
        var createPublicationCommand =
            CreatePublicationCommandFromResourceAssembler.ToCommandFromResource(createPublicationResource);
        var publication = await publicationCommandService.Handle(createPublicationCommand);
        if (publication is null) return BadRequest();
        var resource = PublicationResourceFromEntityAssembler.ToResourceFromEntity(publication);
        return CreatedAtAction(nameof(GetPublicationById), new {publicationId = resource.Id}, resource);
    }
    
    [SwaggerOperation(Summary = "Update publication")]
    [HttpPut("{publicationId}")]
    public async Task<IActionResult> UpdatePublication(
        [FromBody] UpdatePublicationResource updatePublicationResource, [FromRoute] int publicationId)
    {
        var updatePublicationCommand = UpdatePublicationCommandFromResourceAssembler
            .ToCommandFromResource(updatePublicationResource, publicationId);
        var publication = await publicationCommandService.Handle(updatePublicationCommand);
        var resource = PublicationResourceFromEntityAssembler.ToResourceFromEntity(publication);
        return CreatedAtAction(nameof(GetPublicationById), new {publicationId = resource.Id}, resource);
    }

    [SwaggerOperation(Summary = "Add comment to publication")]
    [HttpPut("{publicationId}/comments")]
    public async Task<IActionResult> AddCommentToPublication(
        [FromBody] AddCommentToPublicationResource addCommentToPublicationResource, [FromRoute] int publicationId)
    {
        var addCommentToPublicationCommand =
            AddCommentToPublicationCommandFromResourceAssembler.ToCommandFromResource(addCommentToPublicationResource,
                publicationId);
        var publication = await publicationCommandService.Handle(addCommentToPublicationCommand);
        var resource = PublicationResourceFromEntityAssembler.ToResourceFromEntity(publication);
        return CreatedAtAction(nameof(GetPublicationById), new { publicationId = resource.Id }, resource);
    }
    
}