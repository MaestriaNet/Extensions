namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Return empty string if <paramref name="value"/> is null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EmptyIfNull(this string value) => value == null ? string.Empty : value;
    }
}