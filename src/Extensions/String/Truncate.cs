using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{

    /// <summary>
    /// Limit <paramref name="value"/>with <paramref name="length"/> character number safe.
    /// </summary>
    /// <param name="value">Full text</param>
    /// <param name="length">Max size of return value</param>
    /// <returns>If input is null value, returns is empty string</returns>
    public static string Truncate(this string? value, int length) => value.SubstringSafe(0, length) ?? string.Empty;

    /// <summary>
    /// Limit <paramref name="value"/>with <paramref name="length"/> character number safe.
    /// </summary>
    /// <param name="value">Full text</param>
    /// <param name="length">Max size of return value</param>
    /// <returns></returns>
    [Obsolete("Use 'Truncate'")]
    public static string? LimitLen(this string? value, int length) => value.SubstringSafe(0, length);
}