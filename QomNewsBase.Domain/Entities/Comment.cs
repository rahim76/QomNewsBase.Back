namespace QomNewsBase.Domain.Entities;

public class Comment : BaseEntity<Guid>
{
    public required string CommentBody { get; set; }
    public bool IsPublished { get; set; }
    public Guid NewsId { get; set; }

    //public Guid CommenterId { get; set; } //=> User


    #region Relations

    public News News { get; set; } = null!;

    #endregion

    #region Methods

    public void Update(string commentBody)
    {
        CommentBody = commentBody;
        UpdatedAt = DateTime.Now;
    }

    #endregion

}