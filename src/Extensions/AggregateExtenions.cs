using System.Linq;

namespace Maestria.Extensions
{
    public static class AggregateExtenions
    {
        public static T Max<T>(params T[] values) => values.Max();

        public static T Min<T>(params T[] values) => values.Min();
    }
}