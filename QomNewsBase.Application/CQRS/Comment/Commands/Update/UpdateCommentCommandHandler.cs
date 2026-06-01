using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Application.CQRS;
public class UpdateCommentCommandHandler(IRepository<Comment> repository)
    : IRequestHandler<UpdateCommentCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await repository.GetByIdAsync(request.Id, cancellationToken);

        comment!.Update(request.CommentBody);

        repository.Update(comment);
        await repository.SaveChangesAsync(cancellationToken);

        return Result<bool>.Ok(true);

    }
}