using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Check value different of null
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool HasValue([NotNullWhen(true)] this object? value) => value != null;

    /// <summary>
    /// Check if text is not null and not white space
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool HasValue([NotNullWhen(true)] this string? value) => !string.IsNullOrWhiteSpace(value);

    /// <summary>
    /// Check if Guid is not empty
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool HasValue(this Guid value) => !value.IsEmpty();

    /// <summary>
    /// Check if Guid is not null and not empty
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool HasValue([NotNullWhen(true)] this Guid? value) => value != null && !value.Value.IsEmpty();
}