using StyleShare.Platform.API.Publications.Domain.Model.Commands;
using StyleShare.Platform.API.Publications.Domain.Model.Entities;

namespace StyleShare.Platform.API.Publications.Domain.Services;

public interface IGarmentCommandService
{
    Task<Garment?> Handle(CreateGarmentCommant command);
    Task<Garment?> Handle(UpdateGarmentCommand command);
}