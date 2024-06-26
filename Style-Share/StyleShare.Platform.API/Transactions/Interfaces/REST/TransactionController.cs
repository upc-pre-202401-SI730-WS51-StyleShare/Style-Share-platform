using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using StyleShare.Platform.API.Transactions.Domain.Model.Commands;
using StyleShare.Platform.API.Transactions.Domain.Model.Queries;
using StyleShare.Platform.API.Transactions.Domain.Services;
using StyleShare.Platform.API.Transactions.Interfaces.REST.Resources;
using StyleShare.Platform.API.Transactions.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace StyleShare.Platform.API.Transactions.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class TransactionController(ITransactionQueryService transactionQueryService, ITransactionCommandService transactionCommandService):
    ControllerBase
{
    [SwaggerOperation(Summary = "Get transaction by id")]
    [HttpGet("{transactionId}")]
    public async Task<IActionResult> GetTransactionId(int transactionId)
    {
        var getTransactionByIdQuery = new GetTransactionByIdQuery(transactionId);
        var transaction = await transactionQueryService.Handle(getTransactionByIdQuery);
        var resource = TransactionResourceFromEntityAssembler.ToResourceFromEntity(transaction);
        return Ok(resource);
    }

    [SwaggerOperation(Summary = "Get all transactions")]
    [HttpGet]
    public async Task<IActionResult> GetAllTransaction()
    {
        var query = new GetAllTransactionsQuery();
        var transactions = await transactionQueryService.Handle(query);
        var resources = transactions.Select(TransactionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [SwaggerOperation(Summary = "Create transaction")]
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

    [SwaggerOperation(Summary = "Add rent to transaction")]
    [HttpPut("{transactionId}/Rent")]
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