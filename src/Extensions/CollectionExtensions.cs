using System;
using System.Collections.Generic;
using System.Linq;

namespace Maestria.Extensions
{
    public static class CollectionExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null) return;
            foreach (var item in enumerable)
                action.Invoke(item);
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable) => enumerable == null || !enumerable.Any();

        public static bool HasItems<T>(this IEnumerable<T> enumerable) => enumerable != null && enumerable.Any();
    }
}
