using StyleShare.Platform.API.Transactions.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Transactions.Interfaces.REST.Resources;

public record TransactionResource(int Id, string Details, int Amount, EPaymentMethod PaymentMethod, List<int> RentIds);