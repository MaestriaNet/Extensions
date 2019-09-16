using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maestria.Extensions
{
    public static class CollectionExtensions
    {
        #region IEnumerable Iterate

        public static void Iterate(this IEnumerable enumerable, Action<object> action)
        {
            if (enumerable == null) return;
            foreach (var item in enumerable)
                action.Invoke(item);
        }

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

        public static async Task IterateAsync(this IEnumerable enumerable, Func<object, Task> action)
        {
            if (enumerable == null) return;
            foreach (var item in enumerable)
                await action.Invoke(item);
        }

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

        public static void Iterate<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null) return;
            foreach (var item in enumerable)
                action.Invoke(item);
        }

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

        public static async Task IterateAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
        {
            if (enumerable == null) return;
            foreach (var item in enumerable)
                await action.Invoke(item);
        }

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

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable) => enumerable == null || !enumerable.Any();

        public static bool HasItems<T>(this IEnumerable<T> enumerable) => enumerable != null && enumerable.Any();
    }
}
