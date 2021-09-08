using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Return enumerable tuple with index and item for use into foreach
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <example>foreach (var (Item, Index) in youtList.WithIndex())
        /// {
        /// ...
        /// }</example>
        public static IEnumerable<(object Item, int Index)> WithIndex(this IEnumerable source) =>
            source.Cast<object>().Select((Item, Index) => (Item, Index));

        /// <summary>
        /// Return enumerable tuple with index and item for use into foreach
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <example>foreach (var (Item, Index) in youtList.WithIndex())
        /// {
        /// ...
        /// }</example>
        public static IEnumerable<(T Item, int Index)> WithIndex<T>(this IEnumerable<T> source) =>
            source.Select((Item, Index) => (Item, Index));

    }
}
