using MediatR;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS;
public class GetOneNewsQuery(Guid id) : IRequest<Result<GetOneNewsQueryResult>>
{
    public Guid Id { get; set; } = id;
}
