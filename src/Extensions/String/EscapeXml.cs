namespace Maestria.Extensions
{

    public static partial class MaestriaExtensions
    {

        /// <summary>
        /// Escape <paramref name="value"/> as XML replacing special chars by escape codes.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EscapeXml(this string value) => value
            .Replace("&", "&amp;")
            .Replace("<", "&lt;")
            .Replace(">", "&gt;")
            .Replace("\"", "&quot;")
            .Replace("'", "&apos;");
    }
}