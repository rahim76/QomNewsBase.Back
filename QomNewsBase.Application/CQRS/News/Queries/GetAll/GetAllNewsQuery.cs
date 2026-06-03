using MediatR;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS;

public class GetAllNewsQuery(string? title, int viewsCount, int newsGroupId, int pageNumber = 1, int pageSize = 10)
    : BaseDto(pageNumber, pageSize), IRequest<Result<List<NewsResultDto>>>
{
    public string? Title { get; set; } = title;
    public int ViewsCount { get; set; } = viewsCount;
    public int NewsGroupId { get; set; } = newsGroupId;
    
}