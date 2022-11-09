using System;
using System.Linq;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{

    /// <summary>
    /// Limit <paramref name="value"/> with <paramref name="value"/> character number safe from right to left.
    /// </summary>
    /// <param name="value">Full text</param>
    /// <param name="length">Max size of return value</param>
    /// <returns>If input is null value, returns is empty string</returns>
    public static string TruncateStart(this string? value, int length) => value?.SubstringSafe(new[] { value.Length - length, 0 }.Max(), length) ?? string.Empty;

    /// <summary>
    /// Limit <paramref name="value"/> with <paramref name="value"/> character number safe from right to left.
    /// </summary>
    /// <param name="value">Full text</param>
    /// <param name="length">Max size of return value</param>
    /// <returns></returns>
    [Obsolete("Use 'TruncateStart'")]
    public static string? LimitLenReverse(this string? value, int length) => value?.SubstringSafe(new[] { value.Length - length, 0 }.Max(), length);
}