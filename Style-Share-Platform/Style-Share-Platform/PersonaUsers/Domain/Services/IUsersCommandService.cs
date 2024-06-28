using Style_Share_Platform.PersonaUsers.Domain.Model.Aggregates;
using Style_Share_Platform.PersonaUsers.Domain.Model.Commands;

namespace Style_Share_Platform.PersonaUsers.Domain.Services;

public interface IUsersCommandService
{
    Task<Users?> Handle(CreateUsersCommand command);
}
