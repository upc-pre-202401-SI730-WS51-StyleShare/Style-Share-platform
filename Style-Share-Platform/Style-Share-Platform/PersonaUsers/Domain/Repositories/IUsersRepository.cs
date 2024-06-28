using Style_Share_Platform.PersonaUsers.Domain.Model.Aggregates;
using Style_Share_Platform.PersonaUsers.Domain.Model.ValueObjects;
using Style_Share_Platform.Shared.Domain.Repositories;

namespace Style_Share_Platform.PersonaUsers.Domain.Repositories;

public interface IUsersRepository : IBaseRepository<Users>
{
    Task<Users?> FindUserByDniAsync(PersonDni dni);
}
