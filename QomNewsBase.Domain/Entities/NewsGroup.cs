namespace QomNewsBase.Domain.Entities;

public class NewsGroup : BaseEntity<int>
{
    public required string Title { get; set; }
    public bool IsActive { get; set; }

    #region Relqtions

    public List<News> News { get; set; } = [];

    #endregion

}