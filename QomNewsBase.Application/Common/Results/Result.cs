namespace QomNewsBase.Application.Common.Results;

public class Result
{
    public bool Success { get; private set; }

    public string Message { get; private set; }

    protected Result(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public static Result Ok(string message = "")
    {
        return new Result(true, message);
    }

    public static Result Failure(string message)
    {
        return new Result(false, message);
    }
}