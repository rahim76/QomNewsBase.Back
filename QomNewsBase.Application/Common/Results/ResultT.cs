namespace QomNewsBase.Application.Common.Results;

public class Result<T> : Result
{
    public T? Data { get; private set; }

    private Result(bool success, string message, T? data) : base(success, message)
    {
        Data = data;
    }

    public static Result<T> Ok(T data, string message = "")
    {
        return new Result<T>(true, message, data);
    }

    public static Result<T> Failure(string message)
    {
        return new Result<T>(false, message, default);
    }
}