﻿namespace Maestria.Extensions.DataTypes
{
    /// <summary>
    /// This structure has success and message for simple method result.
    /// </summary>
    public interface ISimpleResult
    {
        public bool Success { get; }
        public string Message { get; }
    }

    /// <summary>
    /// This structure has success and message for simple method result, extensible with generic TData on "Data" property.
    /// </summary>
    public interface ISimpleResult<TData> : ISimpleResult
    {
        public TData Data { get; set; }
    }

    /// <inheritdoc/>>
    public struct SimpleResult : ISimpleResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static SimpleResult Ok(string message = null) => new SimpleResult { Success = true, Message = message };
        public static SimpleResult Fail(string message) => new SimpleResult { Success = false, Message = message };

        public static implicit operator SimpleResult(bool success) => new SimpleResult { Success = success };
        public static implicit operator SimpleResult(string failMessage) => Fail(failMessage);
        public static implicit operator bool(SimpleResult value) => value.Success;
    }

    /// <inheritdoc/>>
    public struct SimpleResult<TData> : ISimpleResult<TData>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }

        public static SimpleResult<TData> Ok(string message = null) => new SimpleResult<TData> { Success = true, Message = message };
        public static SimpleResult<TData> Fail(string message) => new SimpleResult<TData> { Success = false, Message = message };

        public static implicit operator SimpleResult<TData>(bool success) => new SimpleResult<TData> { Success = success };
        public static implicit operator SimpleResult<TData>(string failMessage) => Fail(failMessage);
        public static implicit operator bool(SimpleResult<TData> value) => value.Success;
        public static implicit operator TData(SimpleResult<TData> value) => value.Data;
    }
}
