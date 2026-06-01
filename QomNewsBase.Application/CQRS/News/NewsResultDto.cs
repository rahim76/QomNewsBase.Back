namespace QomNewsBase.Application.CQRS;

public class NewsResultDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Thumbnail { get; set; }
    public int ViewsCount { get; set; }
    public int NewsGroupId { get; set; }
    public string NewsGroupTitle { get; set; } = null!;
    public Guid Id { get; set; }
    public int CommentsCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedAtLocal { get; set; } = null!;
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedAtLocal { get; set; }

}