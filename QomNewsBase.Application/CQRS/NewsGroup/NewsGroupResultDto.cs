namespace QomNewsBase.Application.CQRS;
public class NewsGroupResultDto
{
    public string Title { get; set; } = null!;
    public int Id { get; set; }
    public int NewsCount { get; set; }
}