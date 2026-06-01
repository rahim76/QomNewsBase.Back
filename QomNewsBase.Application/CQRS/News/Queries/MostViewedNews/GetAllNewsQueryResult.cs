namespace QomNewsBase.Application.CQRS;
public class MostViewedNewsResult
{
    public MostVisitedResult? MostVisited { get; set; } = null!; //بیشترین بازدید
    public List<MostVisitedResult> MostViewedNews { get; set; } = [];

}

public class MostVisitedResult
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public int NewsGroupId { get; set; }
    public string NewsGroupTitle { get; set; } = null!;
    public int ViewsCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedAtLocal { get; set; } = null!;
    public int CommentsCount { get; set; }
    public string Description { get; set; } = null!;
    public string? Thumbnail { get; set; }
}
