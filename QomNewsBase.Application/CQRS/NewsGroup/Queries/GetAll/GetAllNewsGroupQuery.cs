using MediatR;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS;
public class GetAllNewsGroupQuery() : IRequest<Result<List<NewsGroupResultDto>>>
{
    public string? Title { get; set; }
}