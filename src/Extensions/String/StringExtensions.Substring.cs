using System;

namespace Maestria.Extensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Extract substring before first occurrence of text pattern. When not found returns null.
        /// </summary>
        /// <param name="value">Full text</param>
        /// <param name="separator">Find text pattern</param>
        /// <param name="autoTrim">Apply trim on result</param>
        /// <returns></returns>
        public static string SubstringBeforeFirstOccurrence(this string value, string separator, bool autoTrim = true)
        {
            if (value == null)
                return null;
            var index = value.IndexOf(separator);
            if (index > 0)
                return autoTrim
                    ? value.Substring(0, index).Trim()
                    : value.Substring(0, index);
            return null;
        }

        /// <summary>
        /// Extract substring before last occurrence of text pattern. When not found returns null.
        /// </summary>
        /// <param name="value">Full text</param>
        /// <param name="separator">Find text pattern</param>
        /// <param name="autoTrim">Apply trim on result</param>
        /// <returns></returns>
        public static string SubstringBeforeLastOccurrence(this string value, string separator, bool autoTrim = true)
        {
            if (value == null)
                return null;
            var index = value.LastIndexOf(separator);
            if (index > 0)
                return autoTrim
                    ? value.Substring(0, index).Trim()
                    : value.Substring(0, index);
            return null;
        }

        /// <summary>
        /// Extract substring after first occurrence of text pattern. When not found returns null.
        /// </summary>
        /// <param name="value">Full text</param>
        /// <param name="separator">Find text pattern</param>
        /// <param name="autoTrim">Apply trim on result</param>
        /// <returns></returns>
        public static string SubstringAfterFirstOccurrence(this string value, string separator, bool autoTrim = true)
        {
            if (value == null)
                return null;
            var index = value.IndexOf(separator);
            if (index > 0)
                return autoTrim
                    ? value.Substring(index + separator.Length, value.Length - index - separator.Length).Trim()
                    : value.Substring(index + separator.Length, value.Length - index - separator.Length);
            return null;
        }

        /// <summary>
        /// Extract substring after last occurrence of text pattern. When not found returns null.
        /// </summary>
        /// <param name="value">Full text</param>
        /// <param name="separator">Find text pattern</param>
        /// <param name="autoTrim">Apply trim on result</param>
        /// <returns></returns>
        public static string SubstringAfterLastOccurrence(this string value, string separator, bool autoTrim = true)
        {
            if (value == null)
                return null;
            var index = value.LastIndexOf(separator);
            if (index > 0)
                return autoTrim
                    ? value.Substring(index + separator.Length, value.Length - index - separator.Length).Trim()
                    : value.Substring(index + separator.Length, value.Length - index - separator.Length);
            return null;
        }

        /// <summary>
        /// Split <paramref name="value"/> by <paramref name="separator"/> and return <paramref name="occurrenceIndex"/> occurrence index. This is a safe method and returns null when then <paramref name="occurrenceIndex"/> was not satisfied.
        /// </summary>
        /// <param name="value">Full text</param>
        /// <param name="separator">Find text pattern</param>
        /// <param name="occurrenceIndex"></param>
        /// <param name="autoTrim">Apply trim on result</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string SubstringAtOccurrenceIndex(this string value, string separator, int occurrenceIndex, bool autoTrim = true, StringSplitOptions options = StringSplitOptions.None)
        {
            if (value == null || occurrenceIndex < 0)
                return null;
            var splited = value.Split(new[] { separator }, options);
            if (occurrenceIndex >= splited.Length)
                return null;
            return autoTrim ? splited[occurrenceIndex].Trim() : splited[occurrenceIndex];
        }

        /// <summary>
        /// Safe substring, when startIndex or length arguments out of bounds returns de limited values
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubstringSafe(this string value, int startIndex, int length)
        {
            if (value.IsNullOrEmpty())
                return value;
            if (startIndex > value.Length)
                return string.Empty;

            if (startIndex < 0)
                startIndex = 0;
            if (startIndex + length > value.Length)
                return value.Substring(startIndex);
            return value.Substring(startIndex, length);
        }
    }
}