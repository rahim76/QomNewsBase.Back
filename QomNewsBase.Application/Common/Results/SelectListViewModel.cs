namespace QomNewsBase.Application.Common.Results;

public class SelectListViewModel<T>
{
    public T Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool Selected { get; set; }
}
