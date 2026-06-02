using MediatR;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS;

public class GetAllAdQuery(string? title, DateTime? startDate, DateTime? endDate, bool? isActive, long? clickCount, int? positionType)
    : IRequest<Result<List<GetAllAdQueryResult>>>
{
    public string? Title { get; set; } = title;
    public DateTime? StartDate { get; set; } = startDate;
    public DateTime? EndDate { get; set; } = endDate;
    public bool? IsActive { get; set; } = isActive;
    public long? ClickCount { get; set; } = clickCount;
    public int? PositionType { get; set; } = positionType;
}