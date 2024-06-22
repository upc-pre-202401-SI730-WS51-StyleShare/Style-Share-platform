using StyleShare.Platform.API.Rent.Domain.Model.Queries;
using StyleShare.Platform.API.Rent.Domain.Repositories;
using StyleShare.Platform.API.Rent.Domain.Services;

namespace StyleShare.Platform.API.Rent.Application.Internal.QueryServices;

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
