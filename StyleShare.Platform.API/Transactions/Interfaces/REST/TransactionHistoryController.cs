﻿using System.Net.Mime;
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
public class TransactionHistoryController(ITransactionHistoryQueryService transactionHistoryQueryService,
    ITransactionHistoryCommandService transactionHistoryCommandService): ControllerBase
{
    [HttpGet("{transactionHistoryId}")]
    public async Task<IActionResult> GetTransactionHistoryById([FromRoute] int transactionHistoryId)
    {
        var transactionHistory =
            await transactionHistoryQueryService.Handle(new GetTransactionHistoryByIdQuery(transactionHistoryId));
        if (transactionHistory is null) return NotFound();
        var resource = TransactionHistoryResourceFromEntityAssembler.ToResourceFromEntity(transactionHistory);
        return Ok(resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTransactionHistory()
    {
        var getAllTransactionHistoryQuery = new GetAllTransactionHistoriesQuery();
        var transactionHistory = await transactionHistoryQueryService.Handle(getAllTransactionHistoryQuery);
        var resources = transactionHistory.Select(TransactionHistoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    //Quizas falle
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
        return CreatedAtAction("nameof()", new { transactionHistoryId = resource.Id }, resource);
    }

    //Quizas falle
    [HttpPost("{transactionHistoryId}/Transaction")]
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
        return CreatedAtAction("nameof()", new { transactionHistoryId = resource.Id }, resource);
    }
}