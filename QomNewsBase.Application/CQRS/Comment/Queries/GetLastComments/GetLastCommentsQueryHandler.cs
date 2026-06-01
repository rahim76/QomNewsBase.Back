using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;
public class GetLastCommentsQueryHandler(ICommentRepository commentRepository)
    : IRequestHandler<GetLastCommentsQuery, Result<List<CommentResultDto>>>
{
    public async Task<Result<List<CommentResultDto>>> Handle(GetLastCommentsQuery request, CancellationToken cancellationToken)
    {
        var result = await commentRepository.GetLastComments(request, cancellationToken);

        return Result<List<CommentResultDto>>.Ok(result);
    }
}