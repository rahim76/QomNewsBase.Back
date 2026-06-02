using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using QomNewsBase.Application.CQRS;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Infrastructure.Contexts;

namespace QomNewsBase.Infrastructure.Repositories;
public class AdRepository(QomNewsBaseContext context, IMapper mapper) : IAdRepository
{
    public async Task<List<GetAllAdQueryResult>> GetAllGroupedByPosition(GetAllAdQuery query, CancellationToken cancellationToken)
    {
        var adsQuery = context.Ads.AsNoTracking()
            .Where(a => string.IsNullOrEmpty(query.Title) || a.Title.Contains(query.Title))
            .Where(a => query.StartDate == null || a.StartDate.Date >= query.StartDate.Value.Date)
            .Where(a => query.EndDate == null || a.EndDate.Date < query.EndDate.Value.Date)
            .Where(a => query.IsActive == null || a.IsActive == query.IsActive)
            .Where(a => query.ClickCount == null || a.ClickCount == query.ClickCount)
            .OrderByDescending(a => a.Priority);

        var groupedAds = await adsQuery
            .GroupBy(a => a.PositionType)
            .ToListAsync(cancellationToken);

        var result = groupedAds
            .Select(g => new GetAllAdQueryResult
            {
                PositionType = g.Key,
                Ads = g.AsQueryable().ProjectTo<AdResultDto>(mapper.ConfigurationProvider).ToList()
            }).ToList();

        return result;
    }
}