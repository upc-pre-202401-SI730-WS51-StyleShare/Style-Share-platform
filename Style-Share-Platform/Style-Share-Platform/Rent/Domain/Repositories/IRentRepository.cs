using Style_Share_Platform.Shared.Domain.Repositories;

namespace Style_Share_Platform.Rent.Domain.Repositories;

public interface IRentRepository : IBaseRepository<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>
{
    Task<IEnumerable<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>> ListRent(); 
    Task<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent?> FindByIdAsync(int id);
    
    //Task AddAsync(Domain.Model.Aggregates.Rent rent);
}