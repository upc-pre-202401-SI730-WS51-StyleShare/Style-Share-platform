using StyleShare.Platform.API.Publications.Domain.Model.Aggregates;
using StyleShare.Platform.API.Publications.Domain.Model.Commands;

namespace StyleShare.Platform.API.Publications.Domain.Services;

public interface IPublicationCommandService
{
    Task<Publication?> Handle(CreatePublicationCommand command);
    Task<Publication?> Handle(UpdatePublicationCommand command);
    Task<Publication?> Handle(AddCommentToPublicationCommand command);
}