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
        /// <param name="values"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        public static IEnumerable Iterate(this IEnumerable values, Action<object> action)
        {
            if (values != null)
                foreach (var item in values)
                    action.Invoke(item);
            return values;
        }

        /// <summary>
        /// Iterate collection
        /// </summary>
        /// <param name="values"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        public static IEnumerable Iterate(this IEnumerable values, IterateCollectionDelegate<object> action)
        {
            if (values != null)
            {
                var index = 0;
                foreach (var item in values)
                    action.Invoke(item, index++);
            }
            return values;
        }

        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="values"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<IEnumerable> Iterate(this IEnumerable values, Func<object, Task> action)
        {
            if (values != null)
                foreach (var item in values)
                    await action.Invoke(item);
            return values;
        }

        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="values"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<IEnumerable> Iterate(this IEnumerable values, IterateCollectionAsyncDelegate<object> action)
        {
            if (values != null)
            {
                var index = 0;
                foreach (var item in values)
                    await action.Invoke(item, index++);
            }
            return values;
        }

        #endregion

        #region IEnumerable<T> Iterate

        /// <summary>
        /// Iterate collection
        /// </summary>
        /// <param name="values"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        public static IEnumerable<T> Iterate<T>(this IEnumerable<T> values, Action<T> action)
        {
            if (values != null)
                foreach (var item in values)
                    action.Invoke(item);
            return values;
        }

        /// <summary>
        /// Iterate collection
        /// </summary>
        /// <param name="values"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        public static IEnumerable<T> Iterate<T>(this IEnumerable<T> values, IterateCollectionDelegate<T> action)
        {
            if (values != null)
            {
                var index = 0;
                foreach (var item in values)
                    action.Invoke(item, index++);
            }
            return values;
        }

        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="values"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<IEnumerable<T>> Iterate<T>(this IEnumerable<T> values, Func<T, Task> action)
        {
            if (values != null)
                foreach (var item in values)
                    await action.Invoke(item);
            return values;
        }

        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="values"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<IEnumerable<T>> Iterate<T>(this IEnumerable<T> values, IterateCollectionAsyncDelegate<T> action)
        {
            if (values != null)
            {
                var index = 0;
                foreach (var item in values)
                    await action.Invoke(item, index++);
            }
            return values;
        }

        #endregion
    }
}
