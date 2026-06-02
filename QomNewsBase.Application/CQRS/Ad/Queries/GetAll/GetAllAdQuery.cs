using MediatR;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS;

public class GetAllAdQuery : IRequest<Result<List<AdResultDto>>>
{

}