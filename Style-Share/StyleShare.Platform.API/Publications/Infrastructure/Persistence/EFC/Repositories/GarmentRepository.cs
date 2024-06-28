using StyleShare.Platform.API.Publications.Domain.Model.Entities;
using StyleShare.Platform.API.Publications.Domain.Repositories;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace StyleShare.Platform.API.Publications.Infrastructure.Persistence.EFC.Repositories;

public class GarmentRepository(AppDBContext context) : BaseRepository<Garment>(context),
                                                        IGarmentRepository
{
    
}