using Microsoft.EntityFrameworkCore;
using Style_Share_Platform.Publications.Domain.Repositories;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Comment = Style_Share_Platform.Publications.Domain.Model.Entities.Comment;

namespace Style_Share_Platform.Publications.Infrastructure.Persistence.EFC.Repositories;

public class CommentRepository(AppDBContext context) : BaseRepository<Comment>(context),
                                                        ICommentRepository
{
    public async Task<IEnumerable<Comment>> FindByPublicationIdAsync(int publicationId)
    {
        return await Context.Set<Comment>()
            .Include(comment => comment.PublicationId)
            .Where(comment => comment.PublicationId == publicationId)
            .ToListAsync();
    }
}