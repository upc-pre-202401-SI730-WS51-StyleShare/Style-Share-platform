using StyleShare.Platform.API.Publications.Domain.Model.Commands;
using StyleShare.Platform.API.Publications.Domain.Model.Entities;

namespace StyleShare.Platform.API.Publications.Domain.Services;

public interface ICommentCommandService
{
    Task<Comment?> Handle(CreateCommentCommand command);
    Task<Comment?> Handle(UpdateCommentCommand command);
}