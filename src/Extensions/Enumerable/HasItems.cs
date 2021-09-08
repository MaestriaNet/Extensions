using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Check if collection is not null and contains items
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool HasItems(this IEnumerable enumerable) => enumerable != null && enumerable.Cast<object>().Any();

        /// <summary>
        /// Check if collection is not null and contains items
        /// </summary>
        /// <param name="enumerable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool HasItems<T>(this IEnumerable<T> enumerable) => enumerable != null && enumerable.Any();
    }
}
