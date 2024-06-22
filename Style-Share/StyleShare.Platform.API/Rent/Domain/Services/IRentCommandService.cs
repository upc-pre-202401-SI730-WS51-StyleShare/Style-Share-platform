using StyleShare.Platform.API.Rent.Domain.Model.Commands;

namespace StyleShare.Platform.API.Rent.Domain.Services;

public interface IRentCommandService
{
    public Task<Model.Aggregates.Rent> Handle(CreateRentCommand command);

}