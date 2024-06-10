using StyleShare.Platform.API.Shared.Domain.Repositories;
using StyleShare.Platform.API.PersonaUsers.Domain.Model.Aggregates;
using StyleShare.Platform.API.PersonaUsers.Domain.Model.Commands;
using StyleShare.Platform.API.PersonaUsers.Domain.Repositories;
using StyleShare.Platform.API.PersonaUsers.Domain.Services;

namespace StyleShare.Platform.API.PersonaUsers.Application.Internal.CommandServices;

public class UsersCommandService(IUsersRepository usersRepository, IUnitOfWork unitOfWork) : IUsersCommandService
{
    public async Task<Domain.Model.Aggregates.Users?> Handle(CreateUsersCommand command)
    {
        var user = new Domain.Model.Aggregates.Users(command);
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
