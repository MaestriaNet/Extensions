using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maestria.Extensions
{
    /// <summary>
    /// Enumerable, Collection and List extensions methods
    /// </summary>
    public static class CollectionExtensions
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
        public static void Iterate(this IEnumerable enumerable, Action<object> action)
        {
            if (enumerable == null) return;
            foreach (var item in enumerable)
                action.Invoke(item);
        }
        
        /// <summary>
        /// Iterate collection
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        public static void Iterate(this IEnumerable enumerable, IterateCollectionDelegate<object> action)
        {
            if (enumerable == null) return;
            var index = 0;
            foreach (var item in enumerable)
                action.Invoke(item, index++);
        }

        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task IterateAsync(this IEnumerable enumerable, Func<object, Task> action)
        {
            if (enumerable == null) return;
            foreach (var item in enumerable)
                await action.Invoke(item);
        }
        
        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task IterateAsync(this IEnumerable enumerable, IterateCollectionAsyncDelegate<object> action)
        {
            if (enumerable == null) return;
            var index = 0;
            foreach (var item in enumerable)
                await action.Invoke(item, index++);
        }
        
        #endregion

        #region IEnumerable<T> Iterate

        /// <summary>
        /// Iterate collection
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        public static void Iterate<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null) return;
            foreach (var item in enumerable)
                action.Invoke(item);
        }
        
        /// <summary>
        /// Iterate collection
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <exception cref="Exception"></exception>
        public static void Iterate<T>(this IEnumerable<T> enumerable, IterateCollectionDelegate<T> action)
        {
            if (enumerable == null) return;
            var index = 0;
            foreach (var item in enumerable)
                action.Invoke(item, index++);
        }

        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task IterateAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
        {
            if (enumerable == null) return;
            foreach (var item in enumerable)
                await action.Invoke(item);
        }
        
        /// <summary>
        /// Iterate collection async
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task IterateAsync<T>(this IEnumerable<T> enumerable, IterateCollectionAsyncDelegate<T> action)
        {
            if (enumerable == null) return;
            var index = 0;
            foreach (var item in enumerable)
                await action.Invoke(item, index++);
        }
        
        #endregion

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
        /// Tentar obter valor da chave, caso não exista retornar o valor default indicado em <see cref="@default"/>
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
