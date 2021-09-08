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
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool HasItems(this IEnumerable values) => values != null && values.Cast<object>().Any();

        /// <summary>
        /// Check if collection is not null and contains items
        /// </summary>
        /// <param name="values"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool HasItems<T>(this IEnumerable<T> values) => values != null && values.Any();
    }
}
