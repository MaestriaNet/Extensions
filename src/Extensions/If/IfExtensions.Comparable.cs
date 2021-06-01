using System;

namespace Maestria.Extensions
{
    public enum ComparisonOperation
    {
        Greater,
        GreaterOrEqual,
        Equal,
        NotEqual,
        Less,
        LessOrEqual
    }

    public struct ThenPromise<TValue, TCompareTo>
        where TValue : struct, IComparable
        where TCompareTo : struct, IComparable
    {
        private TValue _value;
        private TCompareTo _compareTo;
        private ComparisonOperation _operation;
        public ThenPromise(TValue value, TCompareTo compareTo, ComparisonOperation operation)
        {
            _value = value;
            _compareTo = compareTo;
            _operation = operation;
        }

        public TValue Then(TValue newValue)
        {
            TValue result = _operation switch
            {
                ComparisonOperation.Greater => _value.CompareTo(_compareTo) > 0 ? newValue : _value,
                ComparisonOperation.GreaterOrEqual => _value.CompareTo(_compareTo) >= 0 ? newValue : _value,
                ComparisonOperation.Equal => _value.CompareTo(_compareTo) == 0 ? newValue : _value,
                ComparisonOperation.NotEqual => _value.CompareTo(_compareTo) != 0 ? newValue : _value,
                ComparisonOperation.Less => _value.CompareTo(_compareTo) < 0 ? newValue : _value,
                ComparisonOperation.LessOrEqual => _value.CompareTo(_compareTo) <= 0 ? newValue : _value,
                _ => throw new ArgumentOutOfRangeException(nameof(_operation), $"Not expected operation value: {_operation}"),
            };
            return result;
        }
    }

    public static class IfExtensions
    {
        // IfGreater
        public static ThenPromise<T, T> IfGreater<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T, T>(value, compareTo, ComparisonOperation.Greater);
        // public static ThenPromise<T, NullableComparable<T>> IfGreater<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromise<T, NullableComparable<T>>(value, compareTo, Operation.Greater);
        // public static ThenPromise<NullableComparable<T>, T> IfGreater<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromise<NullableComparable<T>, T>(value, compareTo, Operation.Greater);
        // public static ThenPromise<NullableComparable<T>, NullableComparable<T>> IfGreater<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromise<NullableComparable<T>, NullableComparable<T>>(value, compareTo, Operation.Greater);

        // IfGreaterOrEqual
        public static ThenPromise<T, T> IfGreaterOrEqual<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T, T>(value, compareTo, ComparisonOperation.GreaterOrEqual);
        // public static ThenPromise<T, NullableComparable<T>> IfGreaterOrEqual<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromise<T, NullableComparable<T>>(value, compareTo, Operation.GreaterOrEqual);
        // public static ThenPromise<NullableComparable<T>, T> IfGreaterOrEqual<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromise<NullableComparable<T>, T>(value, compareTo, Operation.GreaterOrEqual);
        // public static ThenPromise<NullableComparable<T>, NullableComparable<T>> IfGreaterOrEqual<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromise<NullableComparable<T>, NullableComparable<T>>(value, compareTo, Operation.GreaterOrEqual);

        // IfLess
        public static ThenPromise<T, T> IfLess<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T, T>(value, compareTo, ComparisonOperation.Less);
        // public static ThenPromise<T, NullableComparable<T>> IfLess<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromise<T, NullableComparable<T>>(value, compareTo, Operation.Less);
        // public static ThenPromise<NullableComparable<T>, T> IfLess<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromise<NullableComparable<T>, T>(value, compareTo, Operation.Less);
        // public static ThenPromise<NullableComparable<T>, NullableComparable<T>> IfLess<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromise<NullableComparable<T>, NullableComparable<T>>(value, compareTo, Operation.Less);

        // IfLessOrEqual
        public static ThenPromise<T, T> IfLessOrEqual<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T, T>(value, compareTo, ComparisonOperation.LessOrEqual);
        // public static ThenPromise<T, NullableComparable<T>> IfLessOrEqual<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromise<T, NullableComparable<T>>(value, compareTo, Operation.LessOrEqual);
        // public static ThenPromise<NullableComparable<T>, T> IfLessOrEqual<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromise<NullableComparable<T>, T>(value, compareTo, Operation.LessOrEqual);
        // public static ThenPromise<NullableComparable<T>, NullableComparable<T>> IfLessOrEqual<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromise<NullableComparable<T>, NullableComparable<T>>(value, compareTo, Operation.LessOrEqual);

        // IfEqual
        public static ThenPromise<T, T> If<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T, T>(value, compareTo, ComparisonOperation.Equal);
        // public static ThenPromise<T, NullableComparable<T>> IfEqual<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromise<T, NullableComparable<T>>(value, compareTo, Operation.Equal);
        // public static ThenPromise<NullableComparable<T>, T> IfEqual<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromise<NullableComparable<T>, T>(value, compareTo, Operation.Equal);
        // public static ThenPromise<NullableComparable<T>, NullableComparable<T>> IfEqual<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromise<NullableComparable<T>, NullableComparable<T>>(value, compareTo, Operation.Equal);

        // IfNotEqual
        public static ThenPromise<T, T> IfNot<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T, T>(value, compareTo, ComparisonOperation.NotEqual);
        // public static ThenPromise<T, NullableComparable<T>> IfNotEqual<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromise<T, NullableComparable<T>>(value, compareTo, Operation.NotEqual);
        // public static ThenPromise<NullableComparable<T>, T> IfNotEqual<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromise<NullableComparable<T>, T>(value, compareTo, Operation.NotEqual);
        // public static ThenPromise<NullableComparable<T>, NullableComparable<T>> IfNotEqual<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromise<NullableComparable<T>, NullableComparable<T>>(value, compareTo, Operation.NotEqual);

    }
}