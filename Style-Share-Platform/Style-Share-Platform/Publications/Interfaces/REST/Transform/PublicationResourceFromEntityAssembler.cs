using Style_Share_Platform.Publications.Domain.Model.Aggregates;
using Style_Share_Platform.Publications.Interfaces.REST.Resources;

namespace Style_Share_Platform.Publications.Interfaces.REST.Transform;

public class PublicationResourceFromEntityAssembler
{
    public static PublicationResource ToResourceFromEntity(Publication publication)
    {
        return new PublicationResource(publication.Id, publication.Cost, publication.GarmentId,
            publication.LessorId, publication.Rating, publication.Comments);
    }
}