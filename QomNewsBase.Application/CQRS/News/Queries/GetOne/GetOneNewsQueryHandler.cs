using AutoMapper;
using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Application.CQRS;

public class GetOneNewsQueryHandler(IRepository<News> repository,
    INewsRepository newsRepository,
    IMapper mapper) : IRequestHandler<GetOneNewsQuery, Result<GetOneNewsQueryResult>>
{
    public async Task<Result<GetOneNewsQueryResult>> Handle(GetOneNewsQuery request, CancellationToken cancellationToken)
    {
        var news = await newsRepository.GetByIdAsync(request.Id, cancellationToken);

        #region Visit

        news!.Visit();
        repository.Update(news!);
        await repository.SaveChangesAsync(cancellationToken);

        #endregion

        var result = mapper.Map<GetOneNewsQueryResult>(news);

        return Result<GetOneNewsQueryResult>.Ok(result);

    }
}