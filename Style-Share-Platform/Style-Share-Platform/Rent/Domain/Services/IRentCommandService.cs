using Style_Share_Platform.Rent.Domain.Model.Commands;

namespace Style_Share_Platform.Rent.Domain.Services;

public interface IRentCommandService
{
    public Task<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent> Handle(CreateRentCommand command);

}