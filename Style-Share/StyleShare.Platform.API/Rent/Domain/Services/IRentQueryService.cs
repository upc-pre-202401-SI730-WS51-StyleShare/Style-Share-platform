using StyleShare.Platform.API.Rent.Domain.Model.Queries;

namespace StyleShare.Platform.API.Rent.Domain.Services;

public interface IRentQueryService
{
    Task<IEnumerable<Model.Aggregates.Rent>> Handle(GetAllRentsQuery query);
    Task<Model.Aggregates.Rent> Handle(GetRentByIdQuery query);

        
}