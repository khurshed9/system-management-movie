
using SystemManagementMovie.Common.Extensions;

namespace SystemManagementMovie.Common.Base;

public class BaseResult
{
    public bool IsSuccess { get; init; }

    public Error Error { get; init; }

    public BaseResult(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static BaseResult Success() 
        => new(true, Error.None());

    public static BaseResult Failure(Error error)
        => new(false, error);
}