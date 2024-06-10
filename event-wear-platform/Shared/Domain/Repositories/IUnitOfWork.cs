namespace event_wear_platform.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}