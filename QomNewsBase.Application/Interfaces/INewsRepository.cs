
using QomNewsBase.Application.CQRS;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Application.Interfaces;
public interface INewsRepository
{
    Task<List<NewsResultDto>> FilterAsync(GetAllNewsQuery query, CancellationToken cancellationToken);
    Task<News?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> Any(Guid id, CancellationToken cancellationToken);
    Task<MostViewedNewsResult> GetMostViewedNews(MostViewedNewsQuery query, CancellationToken cancellationToken);
}