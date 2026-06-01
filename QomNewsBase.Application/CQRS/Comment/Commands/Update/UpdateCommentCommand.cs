using MediatR;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS;
public class UpdateCommentCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
    public required string CommentBody { get; set; }
}