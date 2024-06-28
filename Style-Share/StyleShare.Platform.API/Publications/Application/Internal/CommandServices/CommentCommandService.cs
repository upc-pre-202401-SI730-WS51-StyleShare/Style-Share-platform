using StyleShare.Platform.API.Publications.Domain.Model.Commands;
using StyleShare.Platform.API.Publications.Domain.Model.Entities;
using StyleShare.Platform.API.Publications.Domain.Repositories;
using StyleShare.Platform.API.Publications.Domain.Services;
using StyleShare.Platform.API.Shared.Domain.Repositories;

namespace StyleShare.Platform.API.Publications.Application.Internal.CommandServices;

public class CommentCommandService(ICommentRepository commentRepository, IPublicationRepository publicationRepository, IUnitOfWork unitOfWork)
                                    :ICommentCommandService
{
    public async Task<Comment?> Handle(CreateCommentCommand command)
    {
        var comment = new Comment(command.title, command.punctuation, command.description, command.publicationId);
        var publication = await publicationRepository.FindByIdAsync(command.publicationId);
            
        if (publication is null)
        {
            throw new Exception("Publication does not exist");
        }
        
        try
        {
            await commentRepository.AddAsync(comment);
            await unitOfWork.CompleteAsync();
            return comment;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error ocurred while creating comment: {e.Message}");
            return null;
        }
    }

    public async Task<Comment?> Handle(UpdateCommentCommand command)
    {
        var comment = await commentRepository.FindByIdAsync(command.commentId);
        if (comment is null) throw new Exception("Comment not found");
        comment.EditComment(command.title, command.punctuation, command.description);
        await unitOfWork.CompleteAsync();
        return comment;
    }
}
