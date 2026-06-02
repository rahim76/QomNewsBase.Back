using MediatR;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS;
public class GetAllAdQueryHandler : IRequestHandler<GetAllAdQuery, Result<List<AdResultDto>>>
{
    public Task<Result<List<AdResultDto>>> Handle(GetAllAdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
