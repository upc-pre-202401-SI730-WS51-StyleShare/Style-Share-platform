using StyleShare.Platform.API.Publications.Domain.Model.Entities;
using StyleShare.Platform.API.Shared.Domain.Repositories;

namespace StyleShare.Platform.API.Publications.Domain.Repositories;

public interface ICommentRepository : IBaseRepository<Comment>
{
    Task<IEnumerable<Comment>> FindByPublicationIdAsync(int publicationId);
}