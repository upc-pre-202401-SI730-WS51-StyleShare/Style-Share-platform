using Style_Share_Platform.Publications.Domain.Model.Queries;
using Style_Share_Platform.Publications.Domain.Repositories;
using Style_Share_Platform.Publications.Domain.Services;
using Comment = Style_Share_Platform.Publications.Domain.Model.Entities.Comment;

namespace Style_Share_Platform.Publications.Application.Internal.QueryServices;

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

    public async Task<IEnumerable<Comment>> Handle(GetAllCommentsQuery query)
    {
        return await commentRepository.ListAsync();
    }
}