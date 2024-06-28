using StyleShare.Platform.API.Publications.Domain.Model.Aggregates;
using StyleShare.Platform.API.Publications.Domain.Model.Queries;

namespace StyleShare.Platform.API.Publications.Domain.Services;

public interface IPublicationQueryService
{
    Task<Publication?> Handle(GetPublicationByIdQuery query);
    Task<IEnumerable<Publication>> Handle(GetAllPublicationsQuery query);
}