namespace QomNewsBase.Application.CQRS;
public class CommentResultDto
{
    public string CommentBody { get; set; } = null!;
    public bool IsPublished { get; set; }
    public Guid NewsId { get; set; }
    public string NewsTitle { get; set; } = null!;
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedAtLocal { get; set; } = null!;
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedAtLocal { get; set; }
}