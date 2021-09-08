using System;
using System.Text;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        public static string FromBase64(this string base64EncodedData, Encoding encoding = null) =>
            (encoding ?? Encoding.UTF8).GetString(Convert.FromBase64String(base64EncodedData));

        public static byte[] FromBase64(this byte[] base64EncodedData, Encoding encoding = null) =>
            Convert.FromBase64String((encoding ?? Encoding.UTF8).GetString(base64EncodedData));
    }
}