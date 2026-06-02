using QomNewsBase.Domain.Enums;

namespace QomNewsBase.Domain.Entities;

public class Ad : BaseEntity<Guid>
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int Priority { get; set; } //اولویت نمایش
    public string? Thumbnail { get; set; }
    public string TargetUrl { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public long ClickCount { get; set; }//تعداد نمایش
    public AdPositionTypeEnum PositionType { get; set; } = AdPositionTypeEnum.SidebarLeft;

    #region Relations


    #endregion

    #region Methods

    public void Update()
    {

    }

    public void IncreaseClick()
    {
        ClickCount++;
    }

    #endregion

}