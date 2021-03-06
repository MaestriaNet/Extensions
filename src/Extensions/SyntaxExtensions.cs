using System;
using System.Collections;
using System.Linq;

namespace Maestria.Extensions
{
    /// <summary>
    /// Syntax extensions to humanize reading source code
    /// </summary>
    public static class SyntaxExtensions
    {
        /// <summary>
        /// Check value is null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNull(this object value) => value == null;

        /// <summary>
        /// Check value different of null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HasValue(this object value) => value != null;

        /// <summary>
        /// Check value different of null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNotNull(this object value) => value != null;

        /// <summary>
        /// Check if value is contained within expected values
        /// </summary>
        /// <param name="value"></param>
        /// <param name="checkValues"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool In<T>(this T value, params T[] checkValues) =>
            value != null && checkValues != null && checkValues.Contains(value);

        /// <summary>
        /// Check if value is within expected range
        /// </summary>
        /// <param name="value"></param>
        /// <param name="starting"></param>
        /// <param name="ending"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Between<T>(this T value, T starting, T ending) where T : IComparable =>
            value != null && starting != null && ending != null &&
            value.CompareTo(starting) >= 0 && value.CompareTo(ending) <= 0;

        /// <summary>
        /// If <paramref name="maxValue"/> it's bigger of <paramref name="value"/> return <paramref name="maxValue"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxValue">Highest value limit</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T LimitMaxAt<T> (this T value, T maxValue) where T : IComparable => value.CompareTo(maxValue) > 0 ? maxValue : value;

        /// <summary>
        /// If <paramref name="minValue"/> it's smaller of <paramref name="value"/> return <paramref name="minValue"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue">Lower value limit</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T LimitMinAt<T>(this T value, T minValue) where T : IComparable => value.CompareTo(minValue) < 0 ? minValue : value;

        /// <summary>
        /// Call single action method and return current value to continue your build pipeline
        /// </summary>
        /// <param name="value"></param>
        /// <param name="action">Action to execute</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>Return is <paramref name="value"/></returns>
        public static T DetachedInvoke<T>(this T value, Action<T> action)
        {
            if (value == null) return default;

            if (value is IEnumerable enumerable)
            {
                var e = enumerable.GetEnumerator();
                if (e.MoveNext())
                    action(value);
            }
            else
                action(value);

            return value;
        }

        /// <summary>
        /// Create output variable from execute pipeline method
        /// </summary>
        /// <param name="value"></param>
        /// <param name="output"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T OutVar<T>(this T value, out T output)
        {
            output = value;
            return value;
        }
    }
}