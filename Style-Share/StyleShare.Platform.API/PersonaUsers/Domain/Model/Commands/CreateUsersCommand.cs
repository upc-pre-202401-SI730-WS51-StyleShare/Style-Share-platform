namespace StyleShare.Platform.API.PersonaUsers.Domain.Model.Commands;

public record CreateUsersCommand(string Email, string FirstName, string LastName, string Number, string Dni);
