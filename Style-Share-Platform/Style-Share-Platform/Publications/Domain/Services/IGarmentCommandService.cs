using Style_Share_Platform.Publications.Domain.Model.Commands;
using Garment = Style_Share_Platform.Publications.Domain.Model.Entities.Garment;

namespace Style_Share_Platform.Publications.Domain.Services;

public interface IGarmentCommandService
{
    Task<Garment?> Handle(CreateGarmentCommant command);
    Task<Garment?> Handle(UpdateGarmentCommand command);
}