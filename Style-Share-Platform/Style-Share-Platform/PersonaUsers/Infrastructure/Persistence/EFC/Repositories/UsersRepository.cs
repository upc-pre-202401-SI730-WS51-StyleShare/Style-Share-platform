using Microsoft.EntityFrameworkCore;
using Style_Share_Platform.PersonaUsers.Domain.Model.Aggregates;
using Style_Share_Platform.PersonaUsers.Domain.Model.ValueObjects;
using Style_Share_Platform.PersonaUsers.Domain.Repositories;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Style_Share_Platform.PersonaUsers.Infrastructure.Persistence.EFC.Repositories;

public class UsersRepository(AppDBContext context) : BaseRepository<Users>(context), IUsersRepository
{
    public Task<Users?> FindUserByDniAsync(PersonDni dni)
    {
        return Context.Set<Users>().Where(u => u.Dni == dni).FirstOrDefaultAsync();
    }
}
