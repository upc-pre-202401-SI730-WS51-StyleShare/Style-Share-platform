using Style_Share_Platform.Publications.Domain.Model.Queries;
using Comment = Style_Share_Platform.Publications.Domain.Model.Entities.Comment;

namespace Style_Share_Platform.Publications.Domain.Services;

public interface ICommentQueryService
{
    Task<Comment?> Handle(GetCommentByIdQuery query);
    Task<IEnumerable<Comment>> Handle(GetAllCommentsByPublicationIdQuery query);
    Task<IEnumerable<Comment>> Handle(GetAllCommentsQuery query);
}