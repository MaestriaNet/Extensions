using System;
using System.Collections.Generic;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Try get key value, but when it doesn't exist, it returns the value of <paramref name="default"/> argument
    /// </summary>
    /// <param name="values"></param>
    /// <param name="key"></param>
    /// <param name="default"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue>? values, TKey key, TValue @default = default!) =>
        values != null && values.TryGetValue(key, out var value)
            ? value
            : @default;

    /// <summary>
    /// Try get key value, but when it doesn't exist, it returns the value of <paramref name="default"/> argument
    /// </summary>
    /// <param name="values"></param>
    /// <param name="key"></param>
    /// <param name="default"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue>? values, TKey key, Func<TValue> @default) =>
        values != null && values.TryGetValue(key, out var value)
            ? value
            : @default();
}
