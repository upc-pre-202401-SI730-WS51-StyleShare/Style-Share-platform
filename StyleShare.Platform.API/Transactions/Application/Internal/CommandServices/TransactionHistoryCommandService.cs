using StyleShare.Platform.API.Shared.Domain.Repositories;
using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;
using StyleShare.Platform.API.Transactions.Domain.Model.Commands;
using StyleShare.Platform.API.Transactions.Domain.Repositories;
using StyleShare.Platform.API.Transactions.Domain.Services;

namespace StyleShare.Platform.API.Transactions.Application.Internal.CommandServices;

public class TransactionHistoryCommandService(ITransactionHistoryRepository transactionHistoryRepository, IUnitOfWork unitOfWork):
    ITransactionHistoryCommandService
{
    public async Task<TransactionHistory> Handle(CreateTransactionHistoryCommand command)
    {
        var transactionHistory = new TransactionHistory(command);
        await transactionHistoryRepository.AddAsync(transactionHistory);
        await unitOfWork.CompleteAsync();
        return transactionHistory;
    }

    public async Task<TransactionHistory> Handle(AddTransactionToTransactionHistoryCommand command)
    {
        var transactionHistory = await transactionHistoryRepository.FindByIdAsync(command.TransactionHistoryId);
        if(transactionHistory is null) throw new Exception("Transaction history not found");
        transactionHistory.addTransaction(command.TransactionID);
        await unitOfWork.CompleteAsync();
        return transactionHistory;
    }
}