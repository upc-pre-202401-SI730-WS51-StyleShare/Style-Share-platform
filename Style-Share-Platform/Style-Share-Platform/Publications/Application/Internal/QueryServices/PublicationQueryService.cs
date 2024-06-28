using Style_Share_Platform.Publications.Domain.Model.Aggregates;
using Style_Share_Platform.Publications.Domain.Model.Queries;
using Style_Share_Platform.Publications.Domain.Repositories;
using Style_Share_Platform.Publications.Domain.Services;

namespace Style_Share_Platform.Publications.Application.Internal.QueryServices;

public class PublicationQueryService(IPublicationRepository publicationRepository): IPublicationQueryService 
{
    public async Task<Publication?> Handle(GetPublicationByIdQuery query)
    {
        return await publicationRepository.FindByIdAsync(query.publicationId);
    }

    public async Task<IEnumerable<Publication>> Handle(GetAllPublicationsQuery query)
    {
        return await publicationRepository.ListAsync();
    }
}