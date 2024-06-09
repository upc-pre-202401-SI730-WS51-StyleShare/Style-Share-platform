namespace StyleShare.Platform.API.Transactions.Domain.Model.Commands;

public record AddRentToTransactionCommand(int RentId, int TransactionId);