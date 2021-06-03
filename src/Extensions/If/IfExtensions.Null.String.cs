namespace Maestria.Extensions
{
    public static partial class IfExtensions
    {
        /// <summary>
        /// Return <paramref name="default"/> text argument if <paramref name="value"/> is null or empty
        /// </summary>
        /// <param name="value">Current text value</param>
        /// <param name="default">Value to return if <paramref name="value"/> is null or empty</param>
        /// <returns></returns>
        public static string IfNullOrEmpty(this string value, string @default) =>
            value.IsNullOrEmpty() ? @default : value;

        /// <summary>
        /// Return <paramref name="default"/> text argument if <paramref name="value"/> is null or white space
        /// </summary>
        /// <param name="value">Current text value</param>
        /// <param name="default">Value to return if <paramref name="value"/> is null or white space</param>
        /// <returns></returns>
        public static string IfNullOrWhiteSpace(this string value, string @default) =>
            value.IsNullOrWhiteSpace() ? @default : value;
    }
}
