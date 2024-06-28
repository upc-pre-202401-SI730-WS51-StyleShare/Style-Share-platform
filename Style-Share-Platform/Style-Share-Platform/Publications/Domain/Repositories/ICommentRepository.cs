using Style_Share_Platform.Shared.Domain.Repositories;
using Comment = Style_Share_Platform.Publications.Domain.Model.Entities.Comment;

namespace Style_Share_Platform.Publications.Domain.Repositories;

public interface ICommentRepository : IBaseRepository<Comment>
{
    Task<IEnumerable<Comment>> FindByPublicationIdAsync(int publicationId);
}