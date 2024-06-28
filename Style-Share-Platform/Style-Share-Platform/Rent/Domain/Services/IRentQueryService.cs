using Style_Share_Platform.Rent.Domain.Model.Queries;

namespace Style_Share_Platform.Rent.Domain.Services;

public interface IRentQueryService
{
    Task<IEnumerable<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>> Handle(GetAllRentsQuery query);
    Task<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent> Handle(GetRentByIdQuery query);
    
    

        
}