using MediatR;
using Microsoft.AspNetCore.Http;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Domain.Enums;

namespace QomNewsBase.Application.CQRS;

public class CreateAdCommand : IRequest<Result<bool>>
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int Priority { get; set; } //اولویت نمایش
    public IFormFile? Thumbnail { get; set; }
    public string TargetUrl { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public AdPositionTypeEnum PositionType { get; set; }
}