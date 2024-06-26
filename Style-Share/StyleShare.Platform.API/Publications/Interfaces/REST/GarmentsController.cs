﻿using Microsoft.AspNetCore.Mvc;
using StyleShare.Platform.API.Publications.Domain.Model.Queries;
using StyleShare.Platform.API.Publications.Domain.Services;
using StyleShare.Platform.API.Publications.Interfaces.REST.Resources;
using StyleShare.Platform.API.Publications.Interfaces.REST.Transform;
using StyleShare.Platform.API.Shared.Domain.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace StyleShare.Platform.API.Publications.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class GarmentsController(IGarmentCommandService garmentCommandService,
    IGarmentQueryService garmentQueryService) : ControllerBase
{
    [SwaggerOperation(Summary = "Get garment by id")]
    [HttpGet("{garmentId}")]
    public async Task<IActionResult> GetGarmentById([FromRoute] int garmentId)
    {
        var garment = await garmentQueryService.Handle(new GetGarmentByIdQuery(garmentId));
        if (garment is null) return NotFound();
        var resource = GarmentResourceFromEntityAssembler.ToResourceFromEntity(garment);
        return Ok(resource);
    }
    
    [SwaggerOperation(Summary = "Get all garments")]
    [HttpGet]
    public async Task<IActionResult> GetAllGarments()
    {
        var getAllGarmentsQuery = new GetAllGarmentsQuery();
        var garments = await garmentQueryService.Handle(getAllGarmentsQuery);
        var resources = garments.Select(GarmentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [SwaggerOperation(Summary = "Create garment")]
    [HttpPost]
    public async Task<IActionResult> CreateGarment([FromBody] CreateGarmentResource createGarmentResource)
    {
        var createGarmentCommand =
            CreateGarmentCommandFromResourceAssembler.ToCommandFromResource(createGarmentResource);
        var garment = await garmentCommandService.Handle(createGarmentCommand);
        if (garment is null) return BadRequest();
        var resource = GarmentResourceFromEntityAssembler.ToResourceFromEntity(garment);
        Console.WriteLine("resource es: " + resource.Id + resource.description + resource.brand);
        return CreatedAtAction(nameof(GetGarmentById), new { garmentId = resource.Id }, resource);
    }

    [SwaggerOperation(Summary = "Update garment")]
    [HttpPut("{garmentId}")]
    public async Task<IActionResult> UpdateGarmment(
        [FromBody] UpdateGarmentResource updateGarmentResource, [FromRoute] int garmentId)
    {
        var updateGarmentCommand =
            UpdateGarmentCommandFromResourceAssembler.ToCommandFromResource(updateGarmentResource, garmentId);
        var garment = await garmentCommandService.Handle(updateGarmentCommand);
        var resource = GarmentResourceFromEntityAssembler.ToResourceFromEntity(garment);
        return CreatedAtAction(nameof(GetGarmentById), new { garmentId = resource.Id }, resource);
    }
}