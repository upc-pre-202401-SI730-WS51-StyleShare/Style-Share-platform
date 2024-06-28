using System.Collections;
using StyleShare.Platform.API.Publications.Domain.Model.Entities;

namespace StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

public record PublicationResource(int Id, double cost, int garmentId, int lessorId, int rating, ICollection<Comment> comments);