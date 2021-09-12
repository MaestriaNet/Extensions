using System.Text;
using System.Web;

namespace src.Extensions.String
{
    public static partial class MaestriaExtensions
    {
        public static string UrlEncode(this string value) => value != null ? HttpUtility.UrlEncode(value) : null;
        public static string UrlEncode(this string value, Encoding encoding) => value != null ? HttpUtility.UrlEncode(value, encoding) : null;
    }
}