using Style_Share_Platform.Publications.Domain.Model.Commands;
using Style_Share_Platform.Publications.Domain.Repositories;
using Style_Share_Platform.Publications.Domain.Services;
using Style_Share_Platform.Shared.Domain.Repositories;
using Garment = Style_Share_Platform.Publications.Domain.Model.Entities.Garment;

namespace Style_Share_Platform.Publications.Application.Internal.CommandServices;

public class GarmentCommandService(IGarmentRepository garmentRepository, IUnitOfWork unitOfWork)
                                    :IGarmentCommandService
{
    public async Task<Garment?> Handle(CreateGarmentCommant command)
    {
        var garment = new Garment(command.size, command.description, command.material, command.brand, command.timesRented);
        try
        {
            await garmentRepository.AddAsync(garment);
            await unitOfWork.CompleteAsync();
            return garment;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error ocurred while creating garment: {e.Message}");
            return null;
        }
    }

    public async Task<Garment?> Handle(UpdateGarmentCommand command)
    {
        var garment = await garmentRepository.FindByIdAsync(command.garmentId);
        if (garment is null) throw new Exception("Garment not found");
        garment.editGarment(command.size, command.description, command.material, command.brand, command.timesRented);
        await unitOfWork.CompleteAsync();
        return garment;
    }
}