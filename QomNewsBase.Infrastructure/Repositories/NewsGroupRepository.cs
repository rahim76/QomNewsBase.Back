using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QomNewsBase.Application.CQRS;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Infrastructure.Contexts;

namespace QomNewsBase.Infrastructure.Repositories;

public class NewsGroupRepository(QomNewsBaseContext context, IMapper mapper) : INewsGroupRepository
{
    public bool Any(int id)
    {
        return context.NewsGroups.AsNoTracking().Any(a => a.Id == id);
    }

    public async Task<List<NewsGroupResultDto>> GetAllAsync(GetAllNewsGroupQuery query, CancellationToken cancellationToken)
    {
        var groups = await context.NewsGroups
            .AsNoTracking()
            .Include(a => a.News)
            .Where(a => string.IsNullOrEmpty(query.Title) || a.Title.Contains(query.Title))
            .ToListAsync(cancellationToken);

        var result = mapper.Map<List<NewsGroupResultDto>>(groups);
        return result;
    }
}