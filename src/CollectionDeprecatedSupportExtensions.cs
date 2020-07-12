using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Maestria.Extensions
{
    /// <summary>
    /// Enumerable, Collection and List extensions methods
    /// </summary>
    [Obsolete("User 'CollectionExtensions' extension method")]
    public static class CollectionDeprecatedSupportExtensions
    {
        #region IEnumerable Iterate

        /// <summary>
        /// Iterate collection
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        [Obsolete("User 'ForEach' extension method")]
        public static IEnumerable Iterate(this IEnumerable enumerable, Action<object> action) => enumerable.ForEach(action);

        /// <summary>
        /// Iterate collection
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        [Obsolete("User 'ForEach' extension method")]
        public static IEnumerable Iterate(this IEnumerable enumerable, IterateCollectionDelegate<object> action) => enumerable.ForEach(action);

        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Obsolete("User 'ForEach' extension method")]
        public static Task<IEnumerable> IterateAsync(this IEnumerable enumerable, Func<object, Task> action) => enumerable.ForEach(action);

        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Obsolete("User 'ForEach' extension method")]
        public static Task<IEnumerable> IterateAsync(this IEnumerable enumerable, IterateCollectionAsyncDelegate<object> action) => enumerable.ForEach(action);

        #endregion

        #region IEnumerable<T> Iterate

        /// <summary>
        /// Iterate collection
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        [Obsolete("User 'ForEach' extension method")]
        public static IEnumerable<T> Iterate<T>(this IEnumerable<T> enumerable, Action<T> action) => enumerable.ForEach(action);

        /// <summary>
        /// Iterate collection
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        [Obsolete("User 'ForEach' extension method")]
        public static IEnumerable<T> Iterate<T>(this IEnumerable<T> enumerable, IterateCollectionDelegate<T> action) => enumerable.ForEach(action);

        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Obsolete("User 'ForEach' extension method")]
        public static Task<IEnumerable<T>> IterateAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> action) => enumerable.ForEach(action);

        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Obsolete("User 'ForEach' extension method")]
        public static Task<IEnumerable<T>> IterateAsync<T>(this IEnumerable<T> enumerable, IterateCollectionAsyncDelegate<T> action) => enumerable.ForEach(action);

        #endregion
    }
}
