using System;

namespace Maestria.Extensions;

/// <summary>
/// Structure containing success status, message, and optional exception for simple method results.
/// </summary>
public interface IResult
{
    bool Success { get; }
    string? Message { get; }
    Exception? Exception { get; }
}

/// <summary>
/// Structure containing success status, message, optional exception, and generic value.
/// </summary>
public interface IResult<TValue> : IResult
{
    TValue? Value { get; }
    bool SuccessAndHasValue { get; }
    bool HasValue { get; }
}

/// <inheritdoc cref="IResult"/>
public readonly struct Result : IResult
{
    public Result(bool success, string? message = null, Exception? exception = null)
    {
        Success = success;
        Message = message ?? exception?.Message;
        Exception = exception;
    }

    public Result(Exception exception, string? message = null)
    {
        Success = false;
        Message = message ?? exception?.Message;
        Exception = exception;
    }

    public bool Success { get; }
    public string? Message { get; }
    public Exception? Exception { get; }

    public static Result Ok(string? message = null) => new Result(true, message);
    public static Result Fail(string? message, Exception? exception = null) => new Result(false, message, exception);

    public void Deconstruct(out bool success, out string? message)
    {
        success = Success;
        message = Message;
    }

    public static implicit operator Result(bool success) => new Result(success);
    public static implicit operator Result(string failMessage) => Fail(failMessage);
    public static implicit operator Result(Exception? exception) => Fail(exception?.Message, exception);
    public static implicit operator bool(Result value) => value.Success;
    public static implicit operator Exception?(Result value) => value.Exception;
}

/// <inheritdoc cref="IResult{TValue}"/>
public readonly struct Result<TValue> : IResult<TValue>
{
    public Result(TValue? value, string? message = null)
    {
        Success = true;
        Message = message;
        Exception = null;
        Value = value;
    }

    public Result(bool success, TValue? value, string? message = null, Exception? exception = null)
    {
        Success = success;
        Message = message ?? exception?.Message;
        Exception = exception;
        Value = value;
    }

    public Result(Exception? exception, string? message = null)
    {
        Success = false;
        Message = message ?? exception?.Message;
        Exception = exception;
        Value = default;
    }

    public bool Success { get; }
    public string? Message { get; }
    public Exception? Exception { get; }
    public TValue? Value { get; }
    public bool HasValue => Value != null;

    /// <summary>
    /// True if Success and Value != null.
    /// </summary>
    public bool SuccessAndHasValue => Success && HasValue;

    public static Result<TValue> Ok(TValue? value, string? message = null) => new Result<TValue>(true, value, message);
    public static Result<TValue> Ok(string? message = null) => new Result<TValue>(true, default, message);
    public static Result<TValue> Fail(string? message, Exception? exception = null) => new Result<TValue>(false, default, message, exception);

    public void Deconstruct(out bool success, out TValue? value, out string? message)
    {
        success = Success;
        value = Value;
        message = Message;
    }

    public static implicit operator Result<TValue>(bool success) => new Result<TValue>(success, default);
    public static implicit operator Result<TValue>(TValue? value) => Ok(value);
    public static implicit operator Result<TValue>(string? failMessage) => Fail(failMessage);
    public static implicit operator Result<TValue>(Exception? exception) => Fail(exception?.Message, exception);
    
    public static implicit operator Result<TValue>(Result result) => new Result<TValue>
    (
        success: result.Success,
        value: default,
        message: result.Message,
        exception: result.Exception
    );

    public static implicit operator Result(Result<TValue> result) => new Result
    (
        success: result.Success,
        message: result.Message,
        exception: result.Exception
    );

    public static implicit operator bool(Result<TValue> value) => value.Success;
    public static implicit operator TValue?(Result<TValue> value) => value.Value;
    public static implicit operator Exception?(Result<TValue> value) => value.Exception;
}
