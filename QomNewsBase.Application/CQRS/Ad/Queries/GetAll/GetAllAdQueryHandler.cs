using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;
public class GetAllAdQueryHandler(IAdRepository adRepository) : IRequestHandler<GetAllAdQuery, Result<List<AdResultDto>>>
{
    public async Task<Result<List<AdResultDto>>> Handle(GetAllAdQuery query, CancellationToken cancellationToken)
    {
        var result = await adRepository.GetAll(query, cancellationToken);

        return Result<List<AdResultDto>>.Ok(result);
    }
}
