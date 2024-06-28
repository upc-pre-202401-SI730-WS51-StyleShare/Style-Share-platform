using Microsoft.EntityFrameworkCore;
using StyleShare.Platform.API.Publications.Domain.Model.Entities;
using StyleShare.Platform.API.Publications.Domain.Repositories;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace StyleShare.Platform.API.Publications.Infrastructure.Persistence.EFC.Repositories;

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