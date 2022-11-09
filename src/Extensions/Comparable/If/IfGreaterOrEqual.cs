using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    public static ThenPromise<T> IfGreaterOrEqual<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T>(value, compareTo, ComparisonOperation.GreaterOrEqual);
    public static IThenPromise<T> IfGreaterOrEqual<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromiseCompareValueNullable<T>(value, compareTo, ComparisonOperation.GreaterOrEqual);
    public static IThenPromiseNullable<T> IfGreaterOrEqual<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromiseValueNullable<T>(value, compareTo, ComparisonOperation.GreaterOrEqual);
    public static IThenPromiseNullable<T> IfGreaterOrEqual<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromiseNullable<T>(value, compareTo, ComparisonOperation.GreaterOrEqual);
}