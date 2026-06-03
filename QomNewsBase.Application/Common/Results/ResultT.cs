namespace QomNewsBase.Application.Common.Results;

public class Result<T> : Result
{
    public T? Data { get; private set; }
    public int PageNumber { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }
    public bool HasMore { get; private set; }

    private Result(bool success,
        string message,
        T? data,
        int pageNumber = 0,
        int pageSize = 10,
        int totalCount = 0,
        bool hasMore = false) : base(success, message)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
        HasMore = hasMore;
    }

    public static Result<T> Ok(T data,
        string message = "",
        int pageNumber = 0,
        int pageSize = 10,
        int totalCount = 0,
        bool hasMore = false)
    {
        return new Result<T>(true, message, data, pageNumber, pageSize, totalCount, hasMore);
    }

    public static Result<T> Failure(string message)
    {
        return new Result<T>(false, message, default);
    }
}