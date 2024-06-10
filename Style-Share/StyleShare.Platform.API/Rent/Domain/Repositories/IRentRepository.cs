namespace StyleShare.Platform.API.Rent.Domain.Repositories;

public interface IRentRepository
{
    Task<IEnumerable<Model.Aggregates.Rent>> ListRent(); 
    Task<Model.Aggregates.Rent?> FindByIdAsync(int id);
    
    Task AddAsync(Domain.Model.Aggregates.Rent rent);
}