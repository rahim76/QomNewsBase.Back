using QomNewsBase.Application.CQRS;

namespace QomNewsBase.Application.Interfaces;

public interface INewsGroupRepository
{
    bool Any(int id);
    Task<List<NewsGroupResultDto>> GetAllAsync(GetAllNewsGroupQuery query, CancellationToken cancellationToken);
}