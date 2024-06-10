namespace StyleShare.Platform.API.PersonaUsers.Domain.Model.ValueObjects;

public record PersonNumber(string Number)
{
    public PersonNumber() : this(string.Empty)
    {
    }
    
    public string FullNumber => $" {Number}";
}
