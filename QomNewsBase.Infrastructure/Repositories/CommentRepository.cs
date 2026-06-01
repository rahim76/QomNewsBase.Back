using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using QomNewsBase.Application.CQRS;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Infrastructure.Contexts;

namespace QomNewsBase.Infrastructure.Repositories;

public class CommentRepository(QomNewsBaseContext context, IMapper mapper) : ICommentRepository
{
    public async Task<bool> Any(Guid id,CancellationToken cancellationToken)
    {
        return await context.Comments.AsNoTracking().AnyAsync(a => a.Id == id, cancellationToken);
    }

    public async Task<List<CommentResultDto>> GetByNewsId(GetCommentsByNewsIdQuery query, CancellationToken cancellationToken)
    {
        return await context.Comments
            .Include(a => a.News)
            .AsNoTracking()
            .Where(a => a.NewsId == query.NewsId)
            .ProjectTo<CommentResultDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

    }

    public async Task<List<CommentResultDto>> GetLastComments(GetLastCommentsQuery request, CancellationToken cancellationToken)
    {
        return await context.Comments
            .AsNoTracking()
            .Include(a => a.News)
            .OrderByDescending(a => a.CreatedAt)
            .Take(request.TakeCommensCount)
            .ProjectTo<CommentResultDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);


    }
}