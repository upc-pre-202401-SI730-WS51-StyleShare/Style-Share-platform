using StyleShare.Platform.API.Publications.Domain.Model.Entities;
using StyleShare.Platform.API.Publications.Domain.Model.Queries;

namespace StyleShare.Platform.API.Publications.Domain.Services;

public interface ICommentQueryService
{
    Task<Comment?> Handle(GetCommentByIdQuery query);
    Task<IEnumerable<Comment>> Handle(GetAllCommentsByPublicationIdQuery query);
    Task<IEnumerable<Comment>> Handle(GetAllCommentsQuery query);
}