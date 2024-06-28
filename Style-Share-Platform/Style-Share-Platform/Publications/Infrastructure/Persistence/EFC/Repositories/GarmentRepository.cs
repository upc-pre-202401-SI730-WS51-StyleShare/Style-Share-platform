using Style_Share_Platform.Publications.Domain.Repositories;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Garment = Style_Share_Platform.Publications.Domain.Model.Entities.Garment;

namespace Style_Share_Platform.Publications.Infrastructure.Persistence.EFC.Repositories;

public class GarmentRepository(AppDBContext context) : BaseRepository<Garment>(context),
                                                        IGarmentRepository
{
    
}