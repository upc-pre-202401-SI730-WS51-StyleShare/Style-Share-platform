using Style_Share_Platform.PersonaUsers.Domain.Model.Aggregates;
using Style_Share_Platform.PersonaUsers.Domain.Model.Queries;

namespace Style_Share_Platform.PersonaUsers.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<Users>> Handle(GetAllUsersQuery query);
    Task<Users?> Handle(GetUserByDniQuery query);
    Task<Users?> Handle(GetUserByIdQuery query);
    
}
