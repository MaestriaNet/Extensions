namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {

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
    }
}