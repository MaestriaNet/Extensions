namespace Maestria.Extensions.DataTypes
{
    /// <summary>
    /// Auxiliary data type to increment the expressibility of method results when success and failure need different structures.
    /// </summary>
    /// <typeparam name="TSuccess"></typeparam>
    /// <typeparam name="TFailure"></typeparam>
    public struct Try<TSuccess, TFailure>
    {
        private bool? _successfully;
        private TSuccess _success;
        private TFailure _failure;

        public bool Successfully => _successfully != null && _successfully.Value;
        public bool Failed => _successfully != null && !_successfully.Value;
        public TSuccess Success { get => _success; private set { _success = value; _successfully = true; } }
        public TFailure Failure { get => _failure; private set { _failure = value; _successfully = false; } }

        public static Try<TSuccess, TFailure> Ok(TSuccess value) => new Try<TSuccess, TFailure> { Success = value };
        public static Try<TSuccess, TFailure> Fail(TFailure value) => new Try<TSuccess, TFailure> { Failure = value };

        public static implicit operator Try<TSuccess, TFailure>(TSuccess value) => Ok(value);
        public static implicit operator Try<TSuccess, TFailure>(TFailure value) => Fail(value);
        public static implicit operator bool(Try<TSuccess, TFailure> value) => value.Successfully;
        public static implicit operator TSuccess(Try<TSuccess, TFailure> value) => value.Success;
        public static implicit operator TFailure(Try<TSuccess, TFailure> value) => value.Failure;
    }
}
