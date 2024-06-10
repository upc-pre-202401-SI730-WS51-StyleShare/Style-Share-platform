
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using StyleShare.Platform.API.PersonaUsers.Domain.Model.ValueObjects;
using StyleShare.Platform.API.PersonaUsers.Domain.Repositories;
namespace StyleShare.Platform.API.PersonaUsers.Infrastructure.Persistence.EFC.Repositories;

public class UsersRepository(AppDBContext context) : BaseRepository<Domain.Model.Aggregates.Users>(context), IUsersRepository
{
    public Task<Domain.Model.Aggregates.Users?> FindUserByDniAsync(PersonDni dni)
    {
        return Context.Set<Domain.Model.Aggregates.Users>().Where(u => u.Dni == dni).FirstOrDefaultAsync();
    }
}
