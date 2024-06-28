using StyleShare.Platform.API.Publications.Domain.Model.Aggregates;
using StyleShare.Platform.API.Publications.Domain.Repositories;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace StyleShare.Platform.API.Publications.Infrastructure.Persistence.EFC.Repositories;

public class PublicationRepository(AppDBContext context) : BaseRepository<Publication>(context),
                                                    IPublicationRepository
{
    
}