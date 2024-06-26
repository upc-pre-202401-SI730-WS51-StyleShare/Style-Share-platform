namespace StyleShare.Platform.API.Transactions.Interfaces.REST.Resources;

public record TransactionHistoryResource(int Id, List<int> TransactionIds);