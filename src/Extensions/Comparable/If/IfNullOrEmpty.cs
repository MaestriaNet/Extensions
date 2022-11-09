using System;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
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
        /// Return <paramref name="default"/> Guid argument if <paramref name="value"/> is null or empty
        /// </summary>
        /// <param name="value">Current Guid value</param>
        /// <param name="default">Value to return if <paramref name="value"/> is null or empty</param>
        /// <returns></returns>
        public static Guid IfNullOrEmpty(this Guid? value, Guid @default) =>
            value.IsNullOrEmpty() ? @default : value!.Value;
    }
}
