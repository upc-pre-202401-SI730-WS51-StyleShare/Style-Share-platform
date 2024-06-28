using Style_Share_Platform.Publications.Domain.Model.Queries;
using Garment = Style_Share_Platform.Publications.Domain.Model.Entities.Garment;

namespace Style_Share_Platform.Publications.Domain.Services;

public interface IGarmentQueryService
{
    Task<Garment?> Handle(GetGarmentByIdQuery query);
    Task<IEnumerable<Garment>> Handle(GetAllGarmentsQuery query);
}