using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maestria.Extensions
{
    public delegate void IterateCollectionDelegate<in T>(T item, int index);
    public delegate Task IterateCollectionAsyncDelegate<in T>(T item, int index);

    /// <summary>
    /// Enumerable, Collection and List extensions methods
    /// </summary>
    public static class CollectionExtensions
    {
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
            {
                foreach (var item in enumerable)
                    await action.Invoke(item);
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

        /// <summary>
        /// Return enumerable tuple with index and item for use into foreach
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <example>foreach (var (Value, Index) in youtList.WithIndex())
        /// {
        /// ...
        /// }</example>
        public static IEnumerable<(object Value, int Index)> WithIndex(this IEnumerable source) =>
            source.Cast<object>().Select((Item, Index) => (Item, Index));

        /// <summary>
        /// Return enumerable tuple with index and item for use into foreach
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <example>foreach (var (Value, Index) in youtList.WithIndex())
        /// {
        /// ...
        /// }</example>
        public static IEnumerable<(T Value, int Index)> WithIndex<T>(this IEnumerable<T> source) =>
            source.Select((Item, Index) => (Item, Index));

        /// <summary>
        /// Check if collection is null or has no items
        /// </summary>
        /// <param name="enumerable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable) => enumerable == null || !enumerable.Any();

        /// <summary>
        /// Check if collection is not null and contains items
        /// </summary>
        /// <param name="enumerable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool HasItems<T>(this IEnumerable<T> enumerable) => enumerable != null && enumerable.Any();

        /// <summary>
        /// Tentar obter valor da chave, caso não exista retornar o valor default indicado em <paramref name="default"/>
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="default"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key, TValue @default = default) =>
            dictionary != null && dictionary.TryGetValue(key, out var value)
                ? value
                : @default;
    }
}
