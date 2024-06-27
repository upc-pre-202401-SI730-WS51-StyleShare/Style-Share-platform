namespace styleshareCategories_platform.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}