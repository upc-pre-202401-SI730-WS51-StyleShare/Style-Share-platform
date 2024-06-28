namespace Style_Share_Platform.PersonaUsers.Domain.Model.Commands;

public record CreateUsersCommand(string Email, string FirstName, string LastName, string Number, string Dni);
