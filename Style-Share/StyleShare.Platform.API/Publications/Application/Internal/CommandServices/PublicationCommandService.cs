using StyleShare.Platform.API.Publications.Domain.Model.Aggregates;
using StyleShare.Platform.API.Publications.Domain.Model.Commands;
using StyleShare.Platform.API.Publications.Domain.Repositories;
using StyleShare.Platform.API.Publications.Domain.Services;
using StyleShare.Platform.API.Shared.Domain.Repositories;

namespace StyleShare.Platform.API.Publications.Application.Internal.CommandServices;

public class PublicationCommandService(IPublicationRepository publicationRepository, ICommentRepository commentRepository, IUnitOfWork unitOfWork)
                                        :IPublicationCommandService
{
    public async Task<Publication?> Handle(CreatePublicationCommand command)
    {
        var publication = new Publication(command.cost, command.garmentId, command.lessorId, command.rating);
        try
        {
            await publicationRepository.AddAsync(publication);
            await unitOfWork.CompleteAsync();
            return publication;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error ocurred while creating publication: {e.Message}");
            return null;
        }
    }

    public async Task<Publication?> Handle(UpdatePublicationCommand command)
    {
        var publication = await publicationRepository.FindByIdAsync(command.publicationId);
        if (publication is null) throw new Exception("Publication not found");
        publication.editPublication(command.cost, command.garmentId, command.lessorId, command.rating);
        await unitOfWork.CompleteAsync();
        return publication;
    }

    public async Task<Publication?> Handle(AddCommentToPublicationCommand command)
    {
        var publication = await publicationRepository.FindByIdAsync(command.publicationId);
        if (publication is null) throw new Exception("Publication not found");
        var comment = await commentRepository.FindByIdAsync(command.commentId);
        if (comment is null) throw new Exception("Comment not found");
        publication.addComment(comment);
        await unitOfWork.CompleteAsync();
        return publication;
    }
}