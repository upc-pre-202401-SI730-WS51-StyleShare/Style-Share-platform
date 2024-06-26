using Style_Share_Platform.PersonaUsers.Domain.Model.Commands;
using Style_Share_Platform.PersonaUsers.Interfaces.REST.Resources;

namespace Style_Share_Platform.PersonaUsers.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUsersCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new CreateUsersCommand(resource.FirstName, resource.LastName, resource.Email, resource.Number,
            resource.Dni);
    }
}
