using Style_Share_Platform.PersonaUsers.Domain.Model.Aggregates;
using Style_Share_Platform.PersonaUsers.Domain.Model.Queries;
using Style_Share_Platform.PersonaUsers.Domain.Repositories;
using Style_Share_Platform.PersonaUsers.Domain.Services;

namespace Style_Share_Platform.PersonaUsers.Application.Internal.QueryServices;

public class UsersQueryService(IUsersRepository usersRepository) : IUserQueryService
{
    public async Task<IEnumerable<Users>> Handle(GetAllUsersQuery query)
    {
        return await usersRepository.ListAsync();
    }
    
    public async Task<Users?> Handle(GetUserByDniQuery query)
    {
        return await usersRepository.FindUserByDniAsync(query.Dni);
    }
    
    public async Task<Users?> Handle(GetUserByIdQuery query)
    {
        return await usersRepository.FindByIdAsync(query.UserId);
    }
}
