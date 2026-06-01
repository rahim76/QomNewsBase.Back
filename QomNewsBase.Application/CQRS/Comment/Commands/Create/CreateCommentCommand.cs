using MediatR;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS;
public class CreateCommentCommand : IRequest<Result<bool>>
{
    public required string CommentBody { get; set; }
    public bool IsPublished { get; set; } = true; //=> True For Test !
    public Guid NewsId { get; set; }
}