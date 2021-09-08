using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Maestria.Extensions
{
    /// <summary>
    /// Enumerable, Collection and List extensions methods
    /// </summary>
    public static partial class MaestriaExtensions
    {
        public delegate void IterateCollectionDelegate<in T>(T item, int index);
        public delegate Task IterateCollectionAsyncDelegate<in T>(T item, int index);

        #region IEnumerable Iterate

        /// <summary>
        /// Iterate collection
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        public static IEnumerable Iterate(this IEnumerable enumerable, Action<object> action)
        {
            if (enumerable != null)
                foreach (var item in enumerable)
                    action.Invoke(item);
            return enumerable;
        }

        /// <summary>
        /// Iterate collection
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        public static IEnumerable Iterate(this IEnumerable enumerable, IterateCollectionDelegate<object> action)
        {
            if (enumerable != null)
            {
                var index = 0;
                foreach (var item in enumerable)
                    action.Invoke(item, index++);
            }
            return enumerable;
        }

        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<IEnumerable> Iterate(this IEnumerable enumerable, Func<object, Task> action)
        {
            if (enumerable != null)
                foreach (var item in enumerable)
                    await action.Invoke(item);
            return enumerable;
        }

        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<IEnumerable> Iterate(this IEnumerable enumerable, IterateCollectionAsyncDelegate<object> action)
        {
            if (enumerable != null)
            {
                var index = 0;
                foreach (var item in enumerable)
                    await action.Invoke(item, index++);
            }
            return enumerable;
        }

        #endregion

        #region IEnumerable<T> Iterate

        /// <summary>
        /// Iterate collection
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        public static IEnumerable<T> Iterate<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable != null)
                foreach (var item in enumerable)
                    action.Invoke(item);
            return enumerable;
        }

        /// <summary>
        /// Iterate collection
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        public static IEnumerable<T> Iterate<T>(this IEnumerable<T> enumerable, IterateCollectionDelegate<T> action)
        {
            if (enumerable != null)
            {
                var index = 0;
                foreach (var item in enumerable)
                    action.Invoke(item, index++);
            }
            return enumerable;
        }

        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<IEnumerable<T>> Iterate<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
        {
            if (enumerable != null)
                foreach (var item in enumerable)
                    await action.Invoke(item);
            return enumerable;
        }

        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<IEnumerable<T>> Iterate<T>(this IEnumerable<T> enumerable, IterateCollectionAsyncDelegate<T> action)
        {
            if (enumerable != null)
            {
                var index = 0;
                foreach (var item in enumerable)
                    await action.Invoke(item, index++);
            }
            return enumerable;
        }

        #endregion
    }
}
