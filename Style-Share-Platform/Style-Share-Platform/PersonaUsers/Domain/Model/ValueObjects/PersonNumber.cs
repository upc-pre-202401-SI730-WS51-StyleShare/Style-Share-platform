namespace Style_Share_Platform.PersonaUsers.Domain.Model.ValueObjects;

public record PersonNumber(string Number)
{
    public PersonNumber() : this(string.Empty)
    {
    }
    
    public string FullNumber => $" {Number}";
}
