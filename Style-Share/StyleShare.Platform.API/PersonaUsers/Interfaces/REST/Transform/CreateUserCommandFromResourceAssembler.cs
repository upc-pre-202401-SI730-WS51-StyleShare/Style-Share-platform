using StyleShare.Platform.API.PersonaUsers.Domain.Model.Commands;
using StyleShare.Platform.API.PersonaUsers.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.PersonaUsers.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUsersCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new CreateUsersCommand(resource.FirstName, resource.LastName, resource.Email, resource.Number,
            resource.Dni);
    }
}
