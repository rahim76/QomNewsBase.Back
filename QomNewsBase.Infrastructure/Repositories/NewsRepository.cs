using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using QomNewsBase.Application.CQRS;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Domain.Entities;
using QomNewsBase.Infrastructure.Contexts;

namespace QomNewsBase.Infrastructure.Repositories;

public class NewsRepository(QomNewsBaseContext context, IMapper mapper) : INewsRepository
{
    public async Task<bool> Any(Guid id, CancellationToken cancellationToken)
    {
        return await context.News.AsNoTracking().AnyAsync(a => a.Id == id, cancellationToken);
    }

    public async Task<List<NewsResultDto>> FilterAsync(
    GetAllNewsQuery query,
    CancellationToken cancellationToken)
    {
        var newsQuery = context.News
            .AsNoTracking()
            .Include(a => a.NewsGroup)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Title))
        {
            newsQuery = newsQuery.Where(a => a.Title.Contains(query.Title));
        }

        if (query.ViewsCount > 0)
        {
            newsQuery = newsQuery.Where(a =>
                a.ViewsCount == query.ViewsCount);
        }

        if (query.NewsGroupId > 0)
        {
            newsQuery = newsQuery.Where(a =>
                a.NewsGroupId == query.NewsGroupId);
        }

        newsQuery = newsQuery.OrderByDescending(a => a.CreatedAt);

        var skip = (query.PageNumber - 1) * query.PageSize;

        return await newsQuery
        .Skip(skip)
        .Take(query.PageSize)
        .ProjectTo<NewsResultDto>(mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);

    }

    public async Task<News?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.News
            .Include(a => a.NewsGroup)
            .Include(a => a.Comments)
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }

    public async Task<MostViewedNewsResult> GetMostViewedNews(MostViewedNewsQuery query, CancellationToken cancellationToken)
    {
        var topViewedNews = context.News
            .AsNoTracking()
            .Include(a => a.Comments)
            .Include(a => a.NewsGroup)
            .Where(a => query.NewsGroupId <= 0 || a.NewsGroupId == query.NewsGroupId)
            .Where(a => a.ViewsCount > 0)
            .OrderByDescending(a => a.ViewsCount)
            .ThenByDescending(a => a.UpdatedAt)
            .Take(5)
            .AsQueryable();

        return new MostViewedNewsResult
        {
            MostVisited = mapper.Map<MostVisitedResult>(topViewedNews.FirstOrDefault()),
            MostViewedNews = await topViewedNews.Skip(1).ProjectTo<MostVisitedResult>(mapper.ConfigurationProvider).ToListAsync(cancellationToken)
        };
    }

}