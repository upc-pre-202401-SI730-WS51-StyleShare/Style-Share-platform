using StyleShare.Platform.API.PersonaUsers.Domain.Model.Aggregates;
using StyleShare.Platform.API.PersonaUsers.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.PersonaUsers.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(Domain.Model.Aggregates.Users entity)
    {
        return new UserResource(entity.Id, entity.Name.FirstName, entity.Name.LastName, entity.Number.FullNumber);
    }
}
