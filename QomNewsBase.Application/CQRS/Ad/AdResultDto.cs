using QomNewsBase.Domain.Enums;

namespace QomNewsBase.Application.CQRS;
public class AdResultDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int Priority { get; set; } //اولویت نمایش
    public string? Thumbnail { get; set; }
    public string TargetUrl { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public string StartDateLocal { get; set; } = null!;
    public DateTime EndDate { get; set; }
    public string? EndDateLocal { get; set; }
    public bool IsActive { get; set; }
    public long ClickCount { get; set; }//تعداد نمایش
    public AdPositionTypeEnum PositionType { get; set; }
    public string? PositionTypeTitle { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedAtLocal { get; set; } = null!;
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedAtLocal { get; set; }
}