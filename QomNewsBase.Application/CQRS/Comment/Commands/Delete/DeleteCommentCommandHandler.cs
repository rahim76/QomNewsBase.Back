using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Application.CQRS;

public class DeleteCommentCommandHandler(IRepository<Comment> repository) :
    IRequestHandler<DeleteCommentCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new Comment()
        {
            Id = request.Id,
            CommentBody = string.Empty,
        };

        repository.Delete(comment);
        await repository.SaveChangesAsync(cancellationToken);

        return Result<bool>.Ok(true);

    }
}