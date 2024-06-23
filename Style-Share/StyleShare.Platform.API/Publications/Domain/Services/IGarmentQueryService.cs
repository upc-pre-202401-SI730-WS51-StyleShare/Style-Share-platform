using StyleShare.Platform.API.Publications.Domain.Model.Entities;
using StyleShare.Platform.API.Publications.Domain.Model.Queries;

namespace StyleShare.Platform.API.Publications.Domain.Services;

public interface IGarmentQueryService
{
    Task<Garment?> Handle(GetGarmentByIdQuery query);
}