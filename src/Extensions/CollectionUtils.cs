using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable UnusedMember.Global

namespace Maestria.Extensions
{
    public static class CollectionUtils
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null) return;
            foreach (var item in enumerable)
                action.Invoke(item);
        }

        public static bool IsEmpty<T>(this IEnumerable<T> enumerable) => enumerable == null || !enumerable.Any();

        public static bool HasItems<T>(this IEnumerable<T> enumerable) => enumerable != null && enumerable.Any();
    }
}
