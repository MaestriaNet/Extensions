using System;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        public static ThenPromise<T> IfLess<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T>(value, compareTo, ComparisonOperation.Less);
        public static IThenPromise<T> IfLess<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromiseCompareValueNullable<T>(value, compareTo, ComparisonOperation.Less);
        public static IThenPromiseNullable<T> IfLess<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromiseValueNullable<T>(value, compareTo, ComparisonOperation.Less);
        public static IThenPromiseNullable<T> IfLess<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromiseNullable<T>(value, compareTo, ComparisonOperation.Less);
    }
}