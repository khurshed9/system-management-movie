using SystemManagementMovie.Common.Base;

namespace SystemManagementMovie.Common.Extensions;

public class Result<T> : BaseResult
{
    public T? Value { get; set; }
    
    public Result(bool isSuccess, Error error, T? value) : base(isSuccess, error)
    {
        Value = value;
    }

    public static Result<T> Success(T? value) => new(true, Error.None(), value);

    public static Result<T> Fail(Error error) => new(false, error, default);
}