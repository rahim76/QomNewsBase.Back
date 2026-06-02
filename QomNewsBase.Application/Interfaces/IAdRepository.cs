using QomNewsBase.Application.CQRS;

namespace QomNewsBase.Application.Interfaces;

public interface IAdRepository
{
    Task<List<GetAllAdQueryResult>> GetAllGroupedByPosition(GetAllAdQuery query, CancellationToken cancellationToken);
}