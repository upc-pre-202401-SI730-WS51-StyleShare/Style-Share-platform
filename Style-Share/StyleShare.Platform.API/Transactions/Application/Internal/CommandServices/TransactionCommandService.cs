using StyleShare.Platform.API.Shared.Domain.Repositories;
using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;
using StyleShare.Platform.API.Transactions.Domain.Model.Commands;
using StyleShare.Platform.API.Transactions.Domain.Repositories;
using StyleShare.Platform.API.Transactions.Domain.Services;

namespace StyleShare.Platform.API.Transactions.Application.Internal.CommandServices;

public class TransactionCommandService(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork):
    ITransactionCommandService
{
    public async Task<Transaction> Handle(CreateTransactionCommand command)
    {
        var transaction = new Transaction(command);
        try
        {
            await transactionRepository.AddAsync(transaction);
            await unitOfWork.CompleteAsync();
            return transaction;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error ocurred while creating the transaction: {e.Message}");
            return null;
        }
    }

    public async Task<Transaction> Handle(AddRentToTransactionCommand command)
    {
        var transaction = await transactionRepository.FindByIdAsync(command.TransactionId);
        if(transaction is null) throw new Exception("Transaction not found");
        transaction.addRent(command.RentId);
        await unitOfWork.CompleteAsync();
        return transaction;
    }
}