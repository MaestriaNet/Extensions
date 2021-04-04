using System;

namespace Maestria.Extensions.DataTypes
{
    /// <summary>
    /// This structure has success and message for simple method result.
    /// </summary>
    public interface ISimpleResult
    {
        public bool Success { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }

    /// <summary>
    /// This structure has success and message for simple method result, extensible with generic TValue on "Value" property.
    /// </summary>
    public interface ISimpleResult<TValue> : ISimpleResult
    {
        public TValue Value { get; }

        [Obsolete("Use property 'Value'. This will removed in future versions.")]
        public TValue Data { get; }
    }

    /// <inheritdoc/>>
    public struct SimpleResult : ISimpleResult
    {
        public SimpleResult(bool success, string message = null, Exception exception = null)
        {
            Success = success;
            Message = message;
            Exception = exception;
        }

        public SimpleResult(Exception exception, string message = null)
        {
            Success = false;
            Message = message ?? exception?.Message;
            Exception = exception;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }

        public static SimpleResult Ok(string message = null) => new SimpleResult { Success = true, Message = message };
        public static SimpleResult Fail(string message, Exception exception = null) => new SimpleResult { Success = false, Message = message, Exception = exception };

        public static implicit operator SimpleResult(bool success) => new SimpleResult { Success = success };
        public static implicit operator SimpleResult(string failMessage) => Fail(failMessage);
        public static implicit operator SimpleResult(Exception exception) => Fail(exception?.Message, exception);
        public static implicit operator bool(SimpleResult value) => value.Success;
    }

    /// <inheritdoc/>>
    public struct SimpleResult<TValue> : ISimpleResult<TValue>
    {
        public SimpleResult(TValue value, string message = null)
        {
            Success = true;
            Message = message;
            Exception = null;
            Value = value;
        }

        public SimpleResult(bool success, TValue value, string message = null, Exception exception = null)
        {
            Success = success;
            Message = message;
            Exception = exception;
            Value = value;
        }

        public SimpleResult(Exception exception, string message = null)
        {
            Success = false;
            Message = message ?? exception?.Message;
            Exception = exception;
            Value = default;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public TValue Value { get; set; }

        [Obsolete("Use property 'Value'. This will removed in future versions.")]
        public TValue Data => Value;

        public static SimpleResult<TValue> Ok(TValue value, string message = null) => new SimpleResult<TValue> { Success = true, Message = message, Value = value };
        public static SimpleResult<TValue> Ok(string message = null) => new SimpleResult<TValue> { Success = true, Message = message };
        public static SimpleResult<TValue> Fail(string message, Exception exception = null) => new SimpleResult<TValue> { Success = false, Message = message, Exception = exception };

        public static implicit operator SimpleResult<TValue>(bool success) => new SimpleResult<TValue> { Success = success };
        public static implicit operator SimpleResult<TValue>(TValue value) => new SimpleResult<TValue> { Success = true, Value = value };
        public static implicit operator SimpleResult<TValue>(string failMessage) => Fail(failMessage);
        public static implicit operator SimpleResult<TValue>(Exception exception) => Fail(exception?.Message, exception);
        public static implicit operator SimpleResult<TValue>(SimpleResult result) => new SimpleResult<TValue> { Success = result.Success, Message = result.Message, Exception = result.Exception, Value = default };
        public static implicit operator SimpleResult(SimpleResult<TValue> result) => new SimpleResult { Success = result.Success, Message = result.Message, Exception = result.Exception };
        public static implicit operator bool(SimpleResult<TValue> value) => value.Success;
        public static implicit operator TValue(SimpleResult<TValue> value) => value.Value;
    }
}
