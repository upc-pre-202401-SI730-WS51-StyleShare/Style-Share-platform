using Style_Share_Platform.Publications.Domain.Model.Aggregates;
using Style_Share_Platform.Publications.Domain.Repositories;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Style_Share_Platform.Publications.Infrastructure.Persistence.EFC.Repositories;

public class PublicationRepository(AppDBContext context) : BaseRepository<Publication>(context),
                                                    IPublicationRepository
{
    
}