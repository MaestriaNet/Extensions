using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    public static ThenPromise<T> IfLessOrEqual<T>(this T value, T compareTo) where T : struct, IComparable => new ThenPromise<T>(value, compareTo, ComparisonOperation.LessOrEqual);
    public static IThenPromise<T> IfLessOrEqual<T>(this T value, T? compareTo) where T : struct, IComparable => new ThenPromiseCompareValueNullable<T>(value, compareTo, ComparisonOperation.LessOrEqual);
    public static IThenPromiseNullable<T> IfLessOrEqual<T>(this T? value, T compareTo) where T : struct, IComparable => new ThenPromiseValueNullable<T>(value, compareTo, ComparisonOperation.LessOrEqual);
    public static IThenPromiseNullable<T> IfLessOrEqual<T>(this T? value, T? compareTo) where T : struct, IComparable => new ThenPromiseNullable<T>(value, compareTo, ComparisonOperation.LessOrEqual);
}