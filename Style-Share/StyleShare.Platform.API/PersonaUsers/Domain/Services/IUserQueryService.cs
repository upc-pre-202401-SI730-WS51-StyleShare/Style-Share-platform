using StyleShare.Platform.API.PersonaUsers.Domain.Model.Aggregates;
using StyleShare.Platform.API.PersonaUsers.Domain.Model.Queries;
namespace StyleShare.Platform.API.PersonaUsers.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<Model.Aggregates.Users>> Handle(GetAllUsersQuery query);
    Task<Model.Aggregates.Users?> Handle(GetUserByDniQuery query);
    Task<Model.Aggregates.Users?> Handle(GetUserByIdQuery query);
    
}
