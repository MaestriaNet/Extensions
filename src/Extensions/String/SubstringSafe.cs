namespace Maestria.Extensions
{

    public static partial class MaestriaExtensions
    {

        /// <summary>
        /// Safe substring, when startIndex or length arguments out of bounds returns de limited values
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string? SubstringSafe(this string? value, int startIndex, int length)
        {
            if (value.IsNullOrEmpty())
                return value;
            if (startIndex > value!.Length)
                return string.Empty;

            if (startIndex < 0)
                startIndex = 0;
            if (startIndex + length > value.Length)
                return value.Substring(startIndex);
            return value.Substring(startIndex, length);
        }
    }
}