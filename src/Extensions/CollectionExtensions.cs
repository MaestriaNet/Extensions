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
        /// Iterate collection safe mode
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        public static void IterateSafe(this IEnumerable enumerable, Action<object> action)
        {
            if (enumerable == null) return;
            foreach (var item in enumerable)
                try
                {
                    action.Invoke(item);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
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
        /// Iterate collection safe and async
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static async Task IterateSafeAsync(this IEnumerable enumerable, Func<object, Task> action)
        {
            if (enumerable == null) return;
            foreach (var item in enumerable)
                try
                {
                    await action.Invoke(item);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
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
        /// Iterate collection safe mode
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        public static void IterateSafe<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null) return;
            foreach (var item in enumerable)
                try
                {
                    action.Invoke(item);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
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
        /// Iterate collection safe and async
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static async Task IterateSafeAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
        {
            if (enumerable == null) return;
            foreach (var item in enumerable)
                try
                {
                    await action.Invoke(item);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
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
    }
}
