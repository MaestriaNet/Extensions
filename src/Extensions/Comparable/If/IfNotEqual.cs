using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    public static ThenPromise<T> IfNot<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T>(value, compareTo, ComparisonOperation.NotEqual);
    public static IThenPromise<T> IfNot<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromiseCompareValueNullable<T>(value, compareTo, ComparisonOperation.NotEqual);
    public static IThenPromiseNullable<T> IfNot<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromiseValueNullable<T>(value, compareTo, ComparisonOperation.NotEqual);
    public static IThenPromiseNullable<T> IfNot<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromiseNullable<T>(value, compareTo, ComparisonOperation.NotEqual);
}