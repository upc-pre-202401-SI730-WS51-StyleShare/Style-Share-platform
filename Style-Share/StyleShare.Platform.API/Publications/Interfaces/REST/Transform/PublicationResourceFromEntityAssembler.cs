using StyleShare.Platform.API.Publications.Domain.Model.Aggregates;
using StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

namespace StyleShare.Platform.API.Publications.Interfaces.REST.Transform;

public class PublicationResourceFromEntityAssembler
{
    public static PublicationResource ToResourceFromEntity(Publication publication)
    {
        return new PublicationResource(publication.Id, publication.Cost, publication.GarmentId,
            publication.LessorId, publication.Rating, publication.Comments);
    }
}