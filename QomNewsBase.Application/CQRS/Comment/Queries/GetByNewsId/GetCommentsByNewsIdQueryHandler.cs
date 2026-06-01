using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;

public class GetCommentsByNewsIdQueryHandler(ICommentRepository commentRepository)
    : IRequestHandler<GetCommentsByNewsIdQuery, Result<List<CommentResultDto>>>
{
    public async Task<Result<List<CommentResultDto>>> Handle(GetCommentsByNewsIdQuery request, CancellationToken cancellationToken)
    {
        var comments = await commentRepository.GetByNewsId(request, cancellationToken);

        return Result<List<CommentResultDto>>.Ok(comments);
    }
}