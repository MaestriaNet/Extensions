using System;

namespace Maestria.Extensions
{
    /// <summary>
    /// This structure has success and message for simple method result.
    /// </summary>
    public interface ISimpleResult
    {
        bool Success { get; }
        string? Message { get; }
        Exception? Exception { get; }
    }

    /// <summary>
    /// This structure has success and message for simple method result, extensible with generic TValue on "Value" property.
    /// </summary>
    public interface ISimpleResult<TValue> : ISimpleResult
    {
        TValue? Value { get; }
        bool SuccessAndHasValue { get; }
        bool HasValue { get; }
    }

    /// <inheritdoc/>>
    public struct SimpleResult : ISimpleResult
    {
        public SimpleResult(bool success, string? message = null, Exception? exception = null)
        {
            Success = success;
            Message = message ?? exception?.Message;
            Exception = exception;
        }

        public SimpleResult(Exception exception, string? message = null)
        {
            Success = false;
            Message = message ?? exception?.Message;
            Exception = exception;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
        public Exception? Exception { get; set; }

        public static SimpleResult Ok(string? message = null) => new SimpleResult(true, message);
        public static SimpleResult Fail(string? message, Exception? exception = null) => new SimpleResult(false, message, exception);

        public static implicit operator SimpleResult(bool success) => new SimpleResult(success);
        public static implicit operator SimpleResult(string failMessage) => Fail(failMessage);
        public static implicit operator SimpleResult(Exception? exception) => Fail(exception?.Message, exception);
        public static implicit operator bool(SimpleResult value) => value.Success;
        public static implicit operator Exception?(SimpleResult value) => value.Exception;
    }

    /// <inheritdoc/>>
    public struct SimpleResult<TValue> : ISimpleResult<TValue>
    {
        public SimpleResult(TValue? value, string? message = null)
        {
            Success = true;
            Message = message;
            Exception = null;
            Value = value;
        }

        public SimpleResult(bool success, TValue? value, string? message = null, Exception? exception = null)
        {
            Success = success;
            Message = message ?? exception?.Message;
            Exception = exception;
            Value = value;
        }

        public SimpleResult(Exception? exception, string? message = null)
        {
            Success = false;
            Message = message ?? exception?.Message;
            Exception = exception;
            Value = default;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
        public Exception? Exception { get; set; }
        public TValue? Value { get; set; }
        public bool HasValue => Value != null;

        /// <summary>
        ///     <para>
        ///         True if Success and Value != null.
        ///     </para>
        ///     <para>
        ///         This is used by implict operator when convert to bool.
        ///     </para>
        /// </summary>
        public bool SuccessAndHasValue => Success && HasValue;

        public static SimpleResult<TValue> Ok(TValue? value, string? message = null) => new SimpleResult<TValue>(true, value, message);
        public static SimpleResult<TValue> Ok(string? message = null) => new SimpleResult<TValue>(true, default, message);
        public static SimpleResult<TValue> Fail(string? message, Exception? exception = null) => new SimpleResult<TValue>(false, default, message, exception);

        public static implicit operator SimpleResult<TValue>(bool success) => new SimpleResult<TValue>(success, default);
        public static implicit operator SimpleResult<TValue>(TValue? value) => Ok(value);
        public static implicit operator SimpleResult<TValue>(string? failMessage) => Fail(failMessage);
        public static implicit operator SimpleResult<TValue>(Exception? exception) => Fail(exception?.Message, exception);
        public static implicit operator SimpleResult<TValue>(SimpleResult result) => new SimpleResult<TValue>
        {
            Success = result.Success,
            Message = result.Message,
            Exception = result.Exception,
            Value = default
        };
        public static implicit operator SimpleResult(SimpleResult<TValue> result) => new SimpleResult
        {
            Success = result.Success,
            Message = result.Message,
            Exception = result.Exception
        };
        public static implicit operator bool(SimpleResult<TValue> value) => value.Success;
        public static implicit operator TValue?(SimpleResult<TValue> value) => value.Value;
        public static implicit operator Exception?(SimpleResult<TValue> value) => value.Exception;
    }
}
