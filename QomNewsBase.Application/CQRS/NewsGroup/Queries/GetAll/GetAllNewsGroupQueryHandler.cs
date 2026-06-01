using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;

public class GetAllNewsGroupQueryHandler(INewsGroupRepository newsGroupRepository)
    : IRequestHandler<GetAllNewsGroupQuery, Result<List<NewsGroupResultDto>>>
{
    public async Task<Result<List<NewsGroupResultDto>>> Handle(GetAllNewsGroupQuery request, CancellationToken cancellationToken)
    {
        var result = await newsGroupRepository.GetAllAsync(request, cancellationToken);

        return Result<List<NewsGroupResultDto>>.Ok(result);

    }
}