using QomNewsBase.Application.CQRS;

namespace QomNewsBase.Application.Interfaces;

public interface IAdRepository
{
    Task<bool> Any(Guid id, CancellationToken cancellationToken);
    Task<List<GetAllAdQueryResult>> GetAllGroupedByPosition(GetAllAdQuery query, CancellationToken cancellationToken);
}