using Style_Share_Platform.Publications.Domain.Model.Aggregates;
using Style_Share_Platform.Publications.Domain.Model.Queries;

namespace Style_Share_Platform.Publications.Domain.Services;

public interface IPublicationQueryService
{
    Task<Publication?> Handle(GetPublicationByIdQuery query);
    Task<IEnumerable<Publication>> Handle(GetAllPublicationsQuery query);
}