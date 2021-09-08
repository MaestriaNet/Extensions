using System;

namespace Maestria.Extensions
{
    public static partial class NullIfExtensions
    {
        /// <summary>
        /// Return null if <paramref name="value"/> is empty string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid? NullIfEmpty(this Guid value) => value.IsEmpty() ? (Guid?)null : value;
    }
}