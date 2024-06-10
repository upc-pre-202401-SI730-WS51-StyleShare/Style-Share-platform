using StyleShare.Platform.API.Shared.Domain.Repositories;
using StyleShare.Platform.API.PersonaUsers.Domain.Model.Aggregates;
using StyleShare.Platform.API.PersonaUsers.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.PersonaUsers.Domain.Repositories;

public interface IUsersRepository : IBaseRepository<Model.Aggregates.Users>
{
    Task<Model.Aggregates.Users?> FindUserByDniAsync(PersonDni dni);
}
