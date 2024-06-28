using StyleShare.Platform.API.Publications.Domain.Model.Entities;
using StyleShare.Platform.API.Publications.Domain.Model.Queries;
using StyleShare.Platform.API.Publications.Domain.Repositories;
using StyleShare.Platform.API.Publications.Domain.Services;

namespace StyleShare.Platform.API.Publications.Application.Internal.QueryServices;

public class GarmentQueryService(IGarmentRepository garmentRepository): IGarmentQueryService
{
    public async Task<Garment?> Handle(GetGarmentByIdQuery query)
    {
        return await garmentRepository.FindByIdAsync(query.garmentId);
    }

    public async Task<IEnumerable<Garment>> Handle(GetAllGarmentsQuery query)
    {
        return await garmentRepository.ListAsync();
    }
}