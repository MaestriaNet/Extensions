namespace Maestria.Extensions.DataTypes
{
    /// <summary>
    /// Auxiliary data type to increment the expressibility of method results when success and failure need different structures.
    /// </summary>
    /// <typeparam name="TSuccess"></typeparam>
    /// <typeparam name="TFailure"></typeparam>
    public struct Try<TSuccess, TFailure>
    {
        public bool Successfully => Success != null;
        public bool Failed => Failure != null;
        public TSuccess Success { get; private set; }
        public TFailure Failure { get; private set; }

        public static Try<TSuccess, TFailure> Ok(TSuccess value) => new Try<TSuccess, TFailure> { Success = value };
        public static Try<TSuccess, TFailure> Fail(TFailure value) => new Try<TSuccess, TFailure> { Failure = value };

        public static implicit operator Try<TSuccess, TFailure>(TSuccess value) => Ok(value);
        public static implicit operator Try<TSuccess, TFailure>(TFailure value) => Fail(value);
        public static implicit operator bool(Try<TSuccess, TFailure> value) => value.Successfully;
        public static implicit operator TSuccess(Try<TSuccess, TFailure> value) => value.Success;
        public static implicit operator TFailure(Try<TSuccess, TFailure> value) => value.Failure;
    }
}
