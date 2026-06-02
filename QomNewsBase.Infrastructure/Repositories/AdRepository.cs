using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using QomNewsBase.Application.CQRS;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Infrastructure.Contexts;

namespace QomNewsBase.Infrastructure.Repositories;
public class AdRepository(QomNewsBaseContext context, IMapper mapper) : IAdRepository
{
    public async Task<List<AdResultDto>> GetAll(GetAllAdQuery query, CancellationToken cancellationToken)
    {
        var result = await context.Ads.AsNoTracking()
            .Where(a => string.IsNullOrEmpty(query.Title) || a.Title.Contains(query.Title))
            .Where(a => query.StartDate == null || a.StartDate.Date >= query.StartDate.Value.Date)
            .Where(a => query.EndDate == null || a.EndDate.Date < query.EndDate.Value.Date)
            .Where(a => query.IsActive == null || a.IsActive == query.IsActive)
            .Where(a => query.ClickCount == null || a.ClickCount == query.ClickCount)
            .Where(a => query.PositionType == null || (int)a.PositionType == query.PositionType)
            .OrderByDescending(a => a.Priority)
            .ProjectTo<AdResultDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result;

    }
}