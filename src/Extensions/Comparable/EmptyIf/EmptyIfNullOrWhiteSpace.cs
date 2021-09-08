namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Return empty string if <paramref name="value"/> is null or white space
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EmptyIfNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value) ? string.Empty : value;
    }
}