using StyleShare.Platform.API.PersonaUsers.Domain.Model.Aggregates;
using StyleShare.Platform.API.PersonaUsers.Domain.Model.Commands;

namespace StyleShare.Platform.API.PersonaUsers.Domain.Services;

public interface IUsersCommandService
{
    Task<Model.Aggregates.Users?> Handle(CreateUsersCommand command);
}
