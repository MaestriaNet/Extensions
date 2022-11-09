using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Check text is null or empty
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value) => string.IsNullOrEmpty(value);

    /// <summary>
    /// Check Guid is null or empty
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty([NotNullWhen(false)] this Guid? value) => value == null || value == Guid.Empty;

    /// <summary>
    /// Check if collection is null or has no items
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty([NotNullWhen(false)] this IEnumerable? values) => values == null || !values.Cast<object>().Any();

    /// <summary>
    /// Check if collection is null or has no items
    /// </summary>
    /// <param name="values"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? values) => values == null || !values.Any();
}