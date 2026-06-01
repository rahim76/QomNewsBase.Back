using MediatR;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS;

public class GetLastCommentsQuery : IRequest<Result<List<CommentResultDto>>>
{
    public int TakeCommensCount { get; set; } = 10;
}