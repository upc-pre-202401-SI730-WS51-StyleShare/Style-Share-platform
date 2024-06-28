using Style_Share_Platform.Publications.Domain.Model.Commands;
using Comment = Style_Share_Platform.Publications.Domain.Model.Entities.Comment;

namespace Style_Share_Platform.Publications.Domain.Services;

public interface ICommentCommandService
{
    Task<Comment?> Handle(CreateCommentCommand command);
    Task<Comment?> Handle(UpdateCommentCommand command);
}