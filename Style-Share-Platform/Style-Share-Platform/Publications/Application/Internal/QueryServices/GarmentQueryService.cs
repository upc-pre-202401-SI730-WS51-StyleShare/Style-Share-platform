using Style_Share_Platform.Publications.Domain.Model.Queries;
using Style_Share_Platform.Publications.Domain.Repositories;
using Style_Share_Platform.Publications.Domain.Services;
using Garment = Style_Share_Platform.Publications.Domain.Model.Entities.Garment;

namespace Style_Share_Platform.Publications.Application.Internal.QueryServices;

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