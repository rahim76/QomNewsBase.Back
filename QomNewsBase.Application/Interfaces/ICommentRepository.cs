using QomNewsBase.Application.CQRS;

namespace QomNewsBase.Application.Interfaces;
public interface ICommentRepository
{
    Task<bool> Any(Guid id,CancellationToken cancellationToken);
    Task<List<CommentResultDto>> GetByNewsId(GetCommentsByNewsIdQuery query, CancellationToken cancellationToken);
    Task<List<CommentResultDto>> GetLastComments(GetLastCommentsQuery request, CancellationToken cancellationToken);
}