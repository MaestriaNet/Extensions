namespace Maestria.Extensions
{
    public static class IfNullExtensions
    {
        #region Default

        /// <summary>
        /// Return <paramref name="default"/> if argument <paramref name="value"/> is null/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="default"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T IfNull<T>(this T? value, T @default) where T : struct
        {
            return value ?? @default;
        }

        #endregion

        #region String

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

        #endregion
    }
}