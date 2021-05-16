using System;

namespace Maestria.Extensions
{
    public static partial class StringExtensions
    {
        [Obsolete("Use TrimStart")]
        public static string RemoveIfStartsWith(this string value, string equality, bool ignoreCase = true) => value.TrimStart(equality, ignoreCase);

        [Obsolete("Use TrimStart")]
        public static string RemoveIfStartsWith(this string value, char equality, bool ignoreCase = true) => value.TrimStart(equality, ignoreCase);

        [Obsolete("Use TrimEnd")]
        public static string RemoveIfEndsWith(this string value, string equality, bool ignoreCase = true) => value.TrimEnd(equality, ignoreCase);

        [Obsolete("Use TrimEnd")]
        public static string RemoveIfEndsWith(this string value, char equality, bool ignoreCase = true) => value.TrimEnd(equality, ignoreCase);
    }
}
