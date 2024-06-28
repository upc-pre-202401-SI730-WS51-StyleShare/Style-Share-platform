using StyleShare.Platform.API.Transactions.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Transactions.Domain.Model.Commands;

public record CreateTransactionCommand(string details, int amount, EPaymentMethod paymentMethod);