using StyleShare.Platform.API.PersonaUsers.Domain.Repositories;
using StyleShare.Platform.API.PersonaUsers.Domain.Services;
using StyleShare.Platform.API.PersonaUsers.Domain.Model.Aggregates;
using StyleShare.Platform.API.PersonaUsers.Domain.Model.Queries;

namespace StyleShare.Platform.API.PersonaUsers.Application.Internal.QueryServices;

public class UsersQueryService(IUsersRepository usersRepository) : IUserQueryService
{
    public async Task<IEnumerable<Domain.Model.Aggregates.Users>> Handle(GetAllUsersQuery query)
    {
        return await usersRepository.ListAsync();
    }
    
    public async Task<Domain.Model.Aggregates.Users?> Handle(GetUserByDniQuery query)
    {
        return await usersRepository.FindUserByDniAsync(query.Dni);
    }
    
    public async Task<Domain.Model.Aggregates.Users?> Handle(GetUserByIdQuery query)
    {
        return await usersRepository.FindByIdAsync(query.UserId);
    }
}
