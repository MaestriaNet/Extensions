namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {

        /// <summary>
        /// Limit <paramref name="value"/>with <paramref name="length"/> character number safe.
        /// </summary>
        /// <param name="value">Full text</param>
        /// <param name="length">Max size of return value</param>
        /// <returns></returns>
        public static string? LimitLen(this string? value, int length) => value.SubstringSafe(0, length);
    }
}