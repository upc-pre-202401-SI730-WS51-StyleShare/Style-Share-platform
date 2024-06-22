using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using StyleShare.Platform.API.Transactions.Domain.Model.Commands;
using StyleShare.Platform.API.Transactions.Domain.Model.Queries;
using StyleShare.Platform.API.Transactions.Domain.Services;
using StyleShare.Platform.API.Transactions.Interfaces.REST.Resources;
using StyleShare.Platform.API.Transactions.Interfaces.REST.Transform;

namespace StyleShare.Platform.API.Transactions.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class TransactionController(ITransactionQueryService transactionQueryService, ITransactionCommandService transactionCommandService):
    ControllerBase
{
    [HttpGet("{transactionId}")]
    public async Task<IActionResult> GetTransactionId(int transactionId)
    {
        var getTransactionByIdQuery = new GetTransactionByIdQuery(transactionId);
        var transaction = await transactionQueryService.Handle(getTransactionByIdQuery);
        var resource = TransactionResourceFromEntityAssembler.ToResourceFromEntity(transaction);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionResource createTransactionResource)
    {
        var createTransactionCommand =
            CreateTransactionCommandFromResourceAssembler.ToCommandFromResource(createTransactionResource);
        var transaction = await transactionCommandService.Handle(createTransactionCommand);
        if (transaction is null) 
            return BadRequest();
        var resource = TransactionResourceFromEntityAssembler.ToResourceFromEntity(transaction);
        return CreatedAtAction(nameof(GetTransactionId), new {transactionId = resource.Id }, resource);
    }

    [HttpPost("{transactionId}/Rent")]
    public async Task<IActionResult> AddRentToTransaction( [FromBody] AddRentToTransactionResource addRentToTransactionResource,
        [FromRoute] int transactionId)
    {
        var addRentToTransactionCommand =
            AddRentToTransactionCommandFromResourceAssembler.ToCommandFromResource(addRentToTransactionResource, transactionId);
        var transaction = await transactionCommandService.Handle(addRentToTransactionCommand);
        var resource = TransactionResourceFromEntityAssembler.ToResourceFromEntity(transaction);
        return CreatedAtAction(nameof(GetTransactionId), new { transactionId = resource.Id }, resource);
    }
}