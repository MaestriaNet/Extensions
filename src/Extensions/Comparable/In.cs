using System.Linq;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {

        /// <summary>
        /// Check if value is contained within expected values
        /// </summary>
        /// <param name="value"></param>
        /// <param name="checkValues"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool In<T>(this T value, params T[] checkValues) =>
            value != null && checkValues != null && checkValues.Contains(value);
    }
}