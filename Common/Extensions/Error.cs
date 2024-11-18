namespace SystemManagementMovie.Common.Extensions;

public sealed record class Error
{
    public int? Code { get; init; }

    public string? Message { get; set; }

    public ErrorTypes ErrorTypes { get; init; }

    public Error()
    {
        Code = 500;
        Message = "Internal server error...";
        ErrorTypes = ErrorTypes.InternalServerError;
    }

    public Error(int? code, string? message, ErrorTypes errorTypes)
    {
        Code = code;
        Message = message;
        ErrorTypes = errorTypes;
    }

    public static Error None()
        => new(null, null, ErrorTypes.None);

    public static Error BadRequest(string? message = "Bad request")
        => new(400, message, ErrorTypes.BadRequest);

    public static Error NotFound(string? message = "Data not found")
        => new(404, message, ErrorTypes.NotFound);

    public static Error Conflict(string? message = "Conflict")
        => new(409, message, ErrorTypes.Conflict);

    public static Error AlreadyExists(string? message = "Already exist")
        => new(409, message, ErrorTypes.AlreadyExist);

    public static Error InternalServerError(string? message = "Internal server error...")
        => new(500, message, ErrorTypes.InternalServerError);
}