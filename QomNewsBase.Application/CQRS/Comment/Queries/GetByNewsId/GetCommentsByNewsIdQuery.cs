using MediatR;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS
{
    public class GetCommentsByNewsIdQuery(Guid newsId) : IRequest<Result<List<CommentResultDto>>>
    {
        public Guid NewsId { get; set; } = newsId;
    }
}