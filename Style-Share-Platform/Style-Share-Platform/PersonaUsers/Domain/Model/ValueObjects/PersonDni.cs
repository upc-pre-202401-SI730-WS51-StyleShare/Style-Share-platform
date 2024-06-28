namespace Style_Share_Platform.PersonaUsers.Domain.Model.ValueObjects;

public record PersonDni(string Dni)
{
    public PersonDni():this (string.Empty)
    {
    }
}
