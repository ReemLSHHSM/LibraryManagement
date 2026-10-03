namespace LibraryManagement.Application.Common.Results;

public class Result<T> : Result
{
    public T? Value { get; }

    private Result(
        bool isSuccess,
        T? value,
        Error? error)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(
            true,
            value,
            null);
    }

    public static Result<T> Failure(Error error)
    {
        return new Result<T>(
            false,
            default,
            error);
    }
}