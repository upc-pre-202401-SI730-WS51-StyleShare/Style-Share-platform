namespace StyleShare.Platform.API.Transactions.Domain.Model.Commands;

public record AddTransactionToTransactionHistoryCommand(int TransactionId, int TransactionHistoryId);