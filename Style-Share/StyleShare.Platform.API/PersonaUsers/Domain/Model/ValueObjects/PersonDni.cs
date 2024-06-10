namespace StyleShare.Platform.API.PersonaUsers.Domain.Model.ValueObjects;

public record PersonDni(string Dni)
{
    public PersonDni():this (string.Empty)
    {
    }
}
