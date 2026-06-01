using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;
public class MostViewedNewsQueryHandler(INewsRepository newsRepository)
    : IRequestHandler<MostViewedNewsQuery, Result<MostViewedNewsResult>>
{
    public async Task<Result<MostViewedNewsResult>> Handle(MostViewedNewsQuery request, CancellationToken cancellationToken)
    {
        var result = await newsRepository.GetMostViewedNews(request, cancellationToken);

        return Result<MostViewedNewsResult>.Ok(result);
    }
}
