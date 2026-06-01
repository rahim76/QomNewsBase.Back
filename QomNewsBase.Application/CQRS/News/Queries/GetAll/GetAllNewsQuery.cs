using MediatR;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS;

public class GetAllNewsQuery(string? title, int viewsCount, int newsGroupId)
    : IRequest<Result<List<NewsResultDto>>>
{
    public string? Title { get; set; } = title;
    public int ViewsCount { get; set; } = viewsCount;
    public int NewsGroupId { get; set; } = newsGroupId;
}