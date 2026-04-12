using ERCMS.Domain.Responses.Errors;

namespace ERCMS.Domain.Responses;

public class Result
{
    private Result(bool isSuccess, object? data, Error? error)
    {
        IsSuccess = isSuccess;
        Data = data;
        Error = error;
    }
    
    public bool IsSuccess { get; set; }
    public object? Data { get; set; }
    public Error? Error { get; set; }

    public static Result Success() => new (true, null, null);
    public static Result Success<TData>(TData data) => new (true, data, null);
    public static Result Failed(Error error) => new (false, null, error);
}