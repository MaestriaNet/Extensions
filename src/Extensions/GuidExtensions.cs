using System;

namespace Maestria.Extensions
{
    public static class GuidExtensions
    {
        /// <summary>
        /// Check Guid is empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this Guid value) => value == Guid.Empty;

        /// <summary>
        /// Check Guid is null or empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this Guid? value) => value == null || value == Guid.Empty;
    }
}