using StyleShare.Platform.API.Transactions.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Transactions.Interfaces.REST.Resources;

public record CreateTransactionResource(string Details, int Amount, EPaymentMethod PaymentMethod);