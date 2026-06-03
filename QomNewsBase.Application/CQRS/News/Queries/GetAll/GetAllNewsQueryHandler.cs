using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;

public class GetAllNewsQueryHandler(INewsRepository newsRepository)
    : IRequestHandler<GetAllNewsQuery, Result<List<NewsResultDto>>>
{
    public async Task<Result<List<NewsResultDto>>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
    {
        var result = await newsRepository.FilterAsync(request, cancellationToken);

        return Result<List<NewsResultDto>>.Ok(result, "", request.PageNumber, request.PageSize, result.Count, result.Count == request.PageSize);

    }
}