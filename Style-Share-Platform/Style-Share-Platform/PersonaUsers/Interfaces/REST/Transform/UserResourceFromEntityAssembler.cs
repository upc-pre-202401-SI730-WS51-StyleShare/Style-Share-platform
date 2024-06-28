using Style_Share_Platform.PersonaUsers.Domain.Model.Aggregates;
using Style_Share_Platform.PersonaUsers.Interfaces.REST.Resources;

namespace Style_Share_Platform.PersonaUsers.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(Users entity)
    {
        return new UserResource(entity.Id, entity.Name.FirstName, entity.Name.LastName, entity.Number.FullNumber);
    }
}
