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

    public static class IfExtensions
    {
        // IfGreater
        public static ThenPromise<T> IfGreater<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T>(value, compareTo, ComparisonOperation.Greater);
        public static IThenPromise<T> IfGreater<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromiseCompareValueNullable<T>(value, compareTo, ComparisonOperation.Greater);
        public static IThenPromise<T> IfGreater<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromiseValueNullable<T>(value, compareTo, ComparisonOperation.Greater);
        public static IThenPromise<T> IfGreater<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromiseNullable<T>(value, compareTo, ComparisonOperation.Greater);

        // IfGreaterOrEqual
        public static ThenPromise<T> IfGreaterOrEqual<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T>(value, compareTo, ComparisonOperation.GreaterOrEqual);
        public static IThenPromise<T> IfGreaterOrEqual<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromiseCompareValueNullable<T>(value, compareTo, ComparisonOperation.GreaterOrEqual);
        public static IThenPromise<T> IfGreaterOrEqual<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromiseValueNullable<T>(value, compareTo, ComparisonOperation.GreaterOrEqual);
        public static IThenPromise<T> IfGreaterOrEqual<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromiseNullable<T>(value, compareTo, ComparisonOperation.GreaterOrEqual);

        // IfLess
        public static ThenPromise<T> IfLess<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T>(value, compareTo, ComparisonOperation.Less);
        public static IThenPromise<T> IfLess<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromiseCompareValueNullable<T>(value, compareTo, ComparisonOperation.Less);
        public static IThenPromise<T> IfLess<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromiseValueNullable<T>(value, compareTo, ComparisonOperation.Less);
        public static IThenPromise<T> IfLess<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromiseNullable<T>(value, compareTo, ComparisonOperation.Less);

        // IfLessOrEqual
        public static ThenPromise<T> IfLessOrEqual<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T>(value, compareTo, ComparisonOperation.LessOrEqual);
        public static IThenPromise<T> IfLessOrEqual<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromiseCompareValueNullable<T>(value, compareTo, ComparisonOperation.LessOrEqual);
        public static IThenPromise<T> IfLessOrEqual<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromiseValueNullable<T>(value, compareTo, ComparisonOperation.LessOrEqual);
        public static IThenPromise<T> IfLessOrEqual<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromiseNullable<T>(value, compareTo, ComparisonOperation.LessOrEqual);

        // IfEqual
        public static ThenPromise<T> If<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T>(value, compareTo, ComparisonOperation.Equal);
        public static IThenPromise<T> If<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromiseCompareValueNullable<T>(value, compareTo, ComparisonOperation.Equal);
        public static IThenPromise<T> If<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromiseValueNullable<T>(value, compareTo, ComparisonOperation.Equal);
        public static IThenPromise<T> If<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromiseNullable<T>(value, compareTo, ComparisonOperation.Equal);

        // IfNotEqual
        public static ThenPromise<T> IfNot<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T>(value, compareTo, ComparisonOperation.NotEqual);
        public static IThenPromise<T> IfNot<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromiseCompareValueNullable<T>(value, compareTo, ComparisonOperation.NotEqual);
        public static IThenPromise<T> IfNot<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromiseValueNullable<T>(value, compareTo, ComparisonOperation.NotEqual);
        public static IThenPromise<T> IfNot<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromiseNullable<T>(value, compareTo, ComparisonOperation.NotEqual);
    }
}