using System;

namespace Maestria.Extensions
{
    public static partial class IfExtensions
    {
        /// <summary>
        /// Return <paramref name="default"/> Guid argument if <paramref name="value"/> is empty
        /// </summary>
        /// <param name="value">Current Guid value</param>
        /// <param name="default">Value to return if <paramref name="value"/> is empty</param>
        /// <returns></returns>
        public static Guid IfEmpty(this Guid value, Guid @default) =>
            value.IsEmpty() ? @default : value;

        /// <summary>
        /// Return <paramref name="default"/> Guid argument if <paramref name="value"/> is null or empty
        /// </summary>
        /// <param name="value">Current Guid value</param>
        /// <param name="default">Value to return if <paramref name="value"/> is null or empty</param>
        /// <returns></returns>
        public static Guid IfNullOrEmpty(this Guid? value, Guid @default) =>
            value.IsNullOrEmpty() ? @default : value.Value;
    }
}
