using System.Linq;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {

        /// <summary>
        /// Limit <paramref name="value"/> with <paramref name="value"/> character number safe from right to left.
        /// </summary>
        /// <param name="value">Full text</param>
        /// <param name="length">Max size of return value</param>
        /// <returns></returns>
        public static string LimitLenReverse(this string value, int length) => value?.SubstringSafe(new[] { value.Length - length, 0 }.Max(), length);
    }
}