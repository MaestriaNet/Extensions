using System;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        public static ThenPromise<T> IfGreater<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T>(value, compareTo, ComparisonOperation.Greater);
        public static IThenPromise<T> IfGreater<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromiseCompareValueNullable<T>(value, compareTo, ComparisonOperation.Greater);
        public static IThenPromiseNullable<T> IfGreater<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromiseValueNullable<T>(value, compareTo, ComparisonOperation.Greater);
        public static IThenPromiseNullable<T> IfGreater<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromiseNullable<T>(value, compareTo, ComparisonOperation.Greater);
    }
}