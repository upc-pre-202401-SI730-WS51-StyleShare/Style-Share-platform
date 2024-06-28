using Style_Share_Platform.PersonaUsers.Domain.Model.Aggregates;
using Style_Share_Platform.PersonaUsers.Domain.Model.Commands;
using Style_Share_Platform.PersonaUsers.Domain.Repositories;
using Style_Share_Platform.PersonaUsers.Domain.Services;
using Style_Share_Platform.Shared.Domain.Repositories;

namespace Style_Share_Platform.PersonaUsers.Application.Internal.CommandServices;

public class UsersCommandService(IUsersRepository usersRepository, IUnitOfWork unitOfWork) : IUsersCommandService
{
    public async Task<Users?> Handle(CreateUsersCommand command)
    {
        var user = new Users(command);
        try
        {
            await usersRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
            return user;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the user: {e.Message}");
            return null;
        }
    }
}
