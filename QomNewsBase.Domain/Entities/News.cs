namespace QomNewsBase.Domain.Entities;

public class News : BaseEntity<Guid>
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string? Thumbnail { get; set; }
    public int ViewsCount { get; set; }
    public int NewsGroupId { get; set; }

    #region Relations

    public virtual NewsGroup NewsGroup { get; set; } = null!;
    public List<Comment> Comments { get; set; } = [];

    #endregion

    #region Methods

    public void Visit()
    {
        ViewsCount++;
        UpdatedAt = DateTime.Now;
    }

    public void Update(string title, string? thumbnail, int newsGroupId,string description)
    {
        Title = title;
        Thumbnail = thumbnail;
        NewsGroupId = newsGroupId;
        UpdatedAt = DateTime.Now;
        Description = description;
    }


    #endregion

}