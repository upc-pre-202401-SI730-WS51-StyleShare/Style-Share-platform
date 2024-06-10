namespace StyleShare.Platform.API.PersonaUsers.Domain.Model.ValueObjects;

public record PersonName(string FirstName, string LastName, string Email)
{
    public PersonName() : this(string.Empty, string.Empty, string.Empty)
    {
    }

    public PersonName(string firstName,string email) : this(firstName, string.Empty, email)
    {
    }

    public string FullName => $"{FirstName} {LastName}{Email}";
}
