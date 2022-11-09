using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    public static ThenPromise<T> If<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T>(value, compareTo, ComparisonOperation.Equal);
    public static IThenPromise<T> If<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromiseCompareValueNullable<T>(value, compareTo, ComparisonOperation.Equal);
    public static IThenPromiseNullable<T> If<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromiseValueNullable<T>(value, compareTo, ComparisonOperation.Equal);
    public static IThenPromiseNullable<T> If<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromiseNullable<T>(value, compareTo, ComparisonOperation.Equal);
}