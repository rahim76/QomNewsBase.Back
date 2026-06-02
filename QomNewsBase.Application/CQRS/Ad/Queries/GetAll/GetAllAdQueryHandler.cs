using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;
public class GetAllAdQueryHandler(IAdRepository adRepository) : IRequestHandler<GetAllAdQuery, Result<List<GetAllAdQueryResult>>>
{
    public async Task<Result<List<GetAllAdQueryResult>>> Handle(GetAllAdQuery query, CancellationToken cancellationToken)
    {
        var result = await adRepository.GetAllGroupedByPosition(query, cancellationToken);

        return Result<List<GetAllAdQueryResult>>.Ok(result);
    }
}
