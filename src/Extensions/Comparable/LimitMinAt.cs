using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{

    /// <summary>
    /// If <paramref name="minValue"/> it's smaller of <paramref name="value"/> return <paramref name="minValue"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="minValue">Lower value limit</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T LimitMinAt<T>(this T value, T minValue) where T : IComparable => value.CompareTo(minValue) < 0 ? minValue : value;
}