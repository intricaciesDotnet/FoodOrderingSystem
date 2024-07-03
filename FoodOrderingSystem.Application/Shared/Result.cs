using Amazon.Runtime;

namespace FoodOrderingSystem.Application.Shared;

public sealed class Result : IResult
{
    public string Message { get; set; } = string.Empty;
    public bool IsSuccess { get; set; } 

    private Result(string message) 
    {
        Message = message;
        IsSuccess = true;
    }

    private Result(ErrorType errorType)
    {
        IsSuccess = false;
    }

    public static Result OnSuccess(string message) => new(message);
    public static Result OnFailure(ErrorType errorType) => new(errorType);
    
}

public sealed class Result<T> : IResult 
    where T : class
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Value { get; set; }
    private Result(string message)
    {
        IsSuccess = false;
        Message = message;
    }

    private Result(T value)
    {
        Value = value;
        IsSuccess = true;
    }

    private Result()
    {
        IsSuccess = true;
        Value = default!;
    }

    public static Result<T> Success(T value) => new(value);
    public static Result<T> Success() => new();
    public static Result<T> Failure(ErrorType errorType) => new(nameof(errorType));
}
