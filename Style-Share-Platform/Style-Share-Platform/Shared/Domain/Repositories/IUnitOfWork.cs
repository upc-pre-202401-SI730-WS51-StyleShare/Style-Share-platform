namespace Style_Share_Platform.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}