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
public class TransactionHistoryController(ITransactionHistoryQueryService transactionHistoryQueryService,
    ITransactionHistoryCommandService transactionHistoryCommandService): ControllerBase
{
    [SwaggerOperation(Summary = "Get transaction history by id")]
    [HttpGet("{transactionHistoryId}")]
    public async Task<IActionResult> GetTransactionHistoryById([FromRoute] int transactionHistoryId)
    {
        var transactionHistory =
            await transactionHistoryQueryService.Handle(new GetTransactionHistoryByIdQuery(transactionHistoryId));
        if (transactionHistory is null) return NotFound();
        var resource = TransactionHistoryResourceFromEntityAssembler.ToResourceFromEntity(transactionHistory);
        return Ok(resource);
    }

    [SwaggerOperation(Summary = "Get all transaction histories")]
    [HttpGet]
    public async Task<IActionResult> GetAllTransactionHistory()
    {
        var getAllTransactionHistoryQuery = new GetAllTransactionHistoriesQuery();
        var transactionHistory = await transactionHistoryQueryService.Handle(getAllTransactionHistoryQuery);
        var resources = transactionHistory.Select(TransactionHistoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [SwaggerOperation(Summary = "Crate transaction history")]
    [HttpPost]
    public async Task<IActionResult> CreateTransactionHistory(
        [FromBody] CreateTransactionHistoryResource createTransactionHistoryResource)
    {
        var createtransactionHistoryCommand =
            CreateTransactionHistoryCommandFromResourceAssembler
                .ToCommandFromResource(createTransactionHistoryResource);
        var transactionHistory = await transactionHistoryCommandService.Handle(createtransactionHistoryCommand);
        if (transactionHistory is null) return BadRequest();
        var resource = TransactionHistoryResourceFromEntityAssembler.ToResourceFromEntity(transactionHistory);
        return CreatedAtAction(nameof(GetTransactionHistoryById), new { transactionHistoryId = resource.Id }, resource);
    }
    
    [SwaggerOperation(Summary = "Add transaction to transaction history")]
    [HttpPut("{transactionHistoryId}/Transaction")]
    public async Task<IActionResult> AddTransactionToTransactionHistory(
        [FromBody] AddTransactionToTransactionHistoryResource addTransactionToTransactionHistoryResource,
        [FromRoute] int transactionHistoryId)
    {
        var addTransactionToTransactionHistoryCommand =
            AddTransactionToTransactionHistoryCommandFromResourceAssembler.ToCommandFromResource(
                addTransactionToTransactionHistoryResource, transactionHistoryId);
        var transactionHistory =
            await transactionHistoryCommandService.Handle(addTransactionToTransactionHistoryCommand);
        var resource = TransactionHistoryResourceFromEntityAssembler.ToResourceFromEntity(transactionHistory);
        return CreatedAtAction(nameof(GetTransactionHistoryById), new { transactionHistoryId = resource.Id }, resource);
    }
}