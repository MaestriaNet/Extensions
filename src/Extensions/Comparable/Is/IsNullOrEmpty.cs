using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Check text is null or empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        /// <summary>
        /// Check Guid is null or empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this Guid? value) => value == null || value == Guid.Empty;

        /// <summary>
        /// Check if collection is null or has no items
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this IEnumerable enumerable) => enumerable == null || !enumerable.Cast<object>().Any();

        /// <summary>
        /// Check if collection is null or has no items
        /// </summary>
        /// <param name="enumerable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable) => enumerable == null || !enumerable.Any();
    }
}