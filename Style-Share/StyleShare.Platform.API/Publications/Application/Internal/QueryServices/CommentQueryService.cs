using StyleShare.Platform.API.Publications.Domain.Model.Entities;
using StyleShare.Platform.API.Publications.Domain.Model.Queries;
using StyleShare.Platform.API.Publications.Domain.Repositories;
using StyleShare.Platform.API.Publications.Domain.Services;

namespace StyleShare.Platform.API.Publications.Application.Internal.QueryServices;

public class CommentQueryService(ICommentRepository commentRepository) : ICommentQueryService
{
    public async Task<Comment?> Handle(GetCommentByIdQuery query)
    {
        return await commentRepository.FindByIdAsync(query.commentId);
    }

    public async Task<IEnumerable<Comment>> Handle(GetAllCommentsByPublicationIdQuery query)
    {
        return await commentRepository.FindByPublicationIdAsync(query.publicationId);
    }
}