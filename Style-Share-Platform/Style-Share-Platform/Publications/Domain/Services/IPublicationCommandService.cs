using Style_Share_Platform.Publications.Domain.Model.Aggregates;
using Style_Share_Platform.Publications.Domain.Model.Commands;

namespace Style_Share_Platform.Publications.Domain.Services;

public interface IPublicationCommandService
{
    Task<Publication?> Handle(CreatePublicationCommand command);
    Task<Publication?> Handle(UpdatePublicationCommand command);
    Task<Publication?> Handle(AddCommentToPublicationCommand command);
}