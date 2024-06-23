using Microsoft.AspNetCore.Mvc;
using StyleShare.Platform.API.Publications.Domain.Model.Queries;
using StyleShare.Platform.API.Publications.Domain.Services;
using StyleShare.Platform.API.Publications.Interfaces.REST.Resources;
using StyleShare.Platform.API.Publications.Interfaces.REST.Transform;

namespace StyleShare.Platform.API.Publications.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class PublicationsController(IPublicationCommandService publicationCommandService,
    IPublicationQueryService publicationQueryService) : ControllerBase
{
    [HttpGet("{publicationId}")]
    public async Task<IActionResult> GetPublicationById([FromRoute] int publicationId)
    {
        var publication = await publicationQueryService.Handle(new GetPublicationByIdQuery(publicationId));
        if (publication is null) return NotFound();
        var resource = PublicationResourceFromEntityAssembler.ToResourceFromEntity(publication);
        return Ok(resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPublications()
    {
        var getAllPublicationsQuery = new GetAllPublicationsQuery();
        var publications = await publicationQueryService.Handle(getAllPublicationsQuery);
        var resources = publications.Select(PublicationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePublication([FromBody] CreatePublicationResource createPublicationResource)
    {
        var createPublicationCommand =
            CreatePublicationCommandFromResourceAssembler.ToCommandFromResource(createPublicationResource);
        var publication = await publicationCommandService.Handle(createPublicationCommand);
        if (publication is null) return BadRequest();
        var resource = PublicationResourceFromEntityAssembler.ToResourceFromEntity(publication);
        return CreatedAtAction(nameof(GetPublicationById), new {publication = resource.Id}, resource);
    }
    
    [HttpPut("{publicationId}")]
    public async Task<IActionResult> UpdatePublication(
        [FromBody] UpdatePublicationResource updatePublicationResource, [FromRoute] int publicationId)
    {
        var updatePublicationCommand = UpdatePublicationCommandFromResourceAssembler
            .ToCommandFromResource(updatePublicationResource, publicationId);
        var publication = await publicationCommandService.Handle(updatePublicationCommand);
        var resource = PublicationResourceFromEntityAssembler.ToResourceFromEntity(publication);
        return CreatedAtAction(nameof(GetPublicationById), new{publicationIdentifier = resource.Id}, resource);
    }

    [HttpPut("{publicationId}/comments")]
    public async Task<IActionResult> AddCommentToPublication(
        [FromBody] AddCommentToPublicationResource addCommentToPublicationResource, [FromRoute] int publicationId)
    {
        var addCommentToPublicationCommand =
            AddCommentToPublicationCommandFromResourceAssembler.ToCommandFromResource(addCommentToPublicationResource,
                publicationId);
        var publication = await publicationCommandService.Handle(addCommentToPublicationCommand);
        var resource = PublicationResourceFromEntityAssembler.ToResourceFromEntity(publication);
        return CreatedAtAction(nameof(GetPublicationById), new { publicationIdentifier = resource.Id }, resource);
    }
    
}