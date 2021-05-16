using System;

namespace Maestria.Extensions
{
    public static partial class StringExtensions
    {
        // Trim
        [Obsolete("Use 'TrimStart'")]
        public static string RemoveIfStartsWith(this string value, string equality, bool ignoreCase = true) => value.TrimStart(equality, ignoreCase);

        [Obsolete("Use 'TrimStart'")]
        public static string RemoveIfStartsWith(this string value, char equality, bool ignoreCase = true) => value.TrimStart(equality, ignoreCase);

        [Obsolete("Use 'TrimEnd'")]
        public static string RemoveIfEndsWith(this string value, string equality, bool ignoreCase = true) => value.TrimEnd(equality, ignoreCase);

        [Obsolete("Use 'TrimEnd'")]
        public static string RemoveIfEndsWith(this string value, char equality, bool ignoreCase = true) => value.TrimEnd(equality, ignoreCase);

        // Concatenation
        [Obsolete("Use 'AddToBeginningIfNotStartsWith'")]
        public static string AddToLeftIfNotStartsWith(this string value, string equality, bool ignoreCase = true) => value.AddToBeginningIfNotStartsWith(equality, ignoreCase);

        [Obsolete("Use 'AddToBeginningIfNotStartsWith'")]
        public static string AddToLeftIfNotStartsWith(this string value, char equality, bool ignoreCase = true) => value.AddToBeginningIfNotStartsWith(equality, ignoreCase);

        [Obsolete("Use 'AddToEndIfNotEndsWith'")]
        public static string AddToRightIfNotEndsWith(this string value, string equality, bool ignoreCase = true) => value.AddToEndIfNotEndsWith(equality, ignoreCase);

        [Obsolete("Use 'AddToEndIfNotEndsWith'")]
        public static string AddToRightIfNotEndsWith(this string value, char equality, bool ignoreCase = true) => value.AddToEndIfNotEndsWith(equality, ignoreCase);

        [Obsolete("Use 'AddToBeginningIfHasValue'")]
        public static string AddToLeftIfHasValue(this string value, string prefix) => value.AddToBeginningIfHasValue(prefix);

        [Obsolete("Use 'AddToBeginningIfHasValue'")]
        public static string AddToLeftIfHasValue(this string value, char prefix) => value.AddToBeginningIfHasValue(prefix);

        [Obsolete("Use 'AddToEndIfHasValue'")]
        public static string AddToRightIfHasValue(this string value, string suffix) => value.AddToEndIfHasValue(suffix);

        [Obsolete("Use 'AddToEndIfHasValue'")]
        public static string AddToRightIfHasValue(this string value, char suffix) => value.AddToEndIfHasValue(suffix);
    }
}
