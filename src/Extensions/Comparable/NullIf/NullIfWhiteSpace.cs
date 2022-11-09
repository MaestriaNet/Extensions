namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Return null if <paramref name="value"/> is white space
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? NullIfWhiteSpace(this string? value) => value.IsNullOrWhiteSpace() ? null : value;
    }
}