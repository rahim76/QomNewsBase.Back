using MediatR;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS;

public class DeleteNewsCommand(Guid id) : IRequest<Result<bool>>
{
    public Guid Id { get; set; } = id;
}