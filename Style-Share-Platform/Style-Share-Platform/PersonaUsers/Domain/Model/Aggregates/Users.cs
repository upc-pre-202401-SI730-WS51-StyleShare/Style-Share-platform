using Style_Share_Platform.PersonaUsers.Domain.Model.Commands;
using Style_Share_Platform.PersonaUsers.Domain.Model.ValueObjects;

namespace Style_Share_Platform.PersonaUsers.Domain.Model.Aggregates;

public  class Users
{
    public Users()
    {
        Name = new PersonName();
        Dni = new PersonDni();
        Number = new PersonNumber();
    }
    
    public Users(string email, string firstName, string lastName, string number, string dni)
    {
        Name = new PersonName(firstName, lastName, email);
        Dni = new PersonDni(dni);
        Number = new PersonNumber(number);
        
    }
    
    public Users(CreateUsersCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName, command.Email);
        Dni = new PersonDni(command.Dni);
        Number = new PersonNumber(command.Number);
    }
    
    
    public int Id { get; }
    
    public PersonName Name { get; private set; }
    public PersonDni Dni { get; private set; }
    
    public PersonNumber Number { get; private set; }
    
    public string FullName => Name.FullName;
    
    public string FullNumber => Number.FullNumber;
    
}
