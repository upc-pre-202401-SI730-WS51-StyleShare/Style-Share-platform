using StyleShare.Platform.API.Publications.Domain.Model.Aggregates;
using StyleShare.Platform.API.Publications.Domain.Model.Queries;
using StyleShare.Platform.API.Publications.Domain.Repositories;
using StyleShare.Platform.API.Publications.Domain.Services;

namespace StyleShare.Platform.API.Publications.Application.Internal.QueryServices;

public class PublicationQueryService(IPublicationRepository publicationRepository): IPublicationQueryService 
{
    public async Task<Publication?> Handle(GetPublicationByIdQuery query)
    {
        return await publicationRepository.FindByIdAsync(query.publicationId);
    }

    public async Task<IEnumerable<Publication>> Handle(GetAllPublications query)
    {
        return await publicationRepository.ListAsync();
    }
}