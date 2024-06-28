using Style_Share_Platform.Rent.Domain.Model.Queries;
using Style_Share_Platform.Rent.Domain.Repositories;
using Style_Share_Platform.Rent.Domain.Services;

namespace Style_Share_Platform.Rent.Application.Internal.QueryServices;

public class RentQueryServices(IRentRepository rentRepository) :IRentQueryService
{
    public async Task<IEnumerable<Domain.Model.Aggregates.Rent>> Handle(GetAllRentsQuery query)
    {
        return await rentRepository.ListRent();
    }

    public async Task<Domain.Model.Aggregates.Rent> Handle(GetRentByIdQuery query)
    {
        return await rentRepository.FindByIdAsync(query.rentId);
    }
    
}
