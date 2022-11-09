using System.Threading.Tasks;
using System.IO;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Save string content on disk
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fileName"></param>
        /// <param name="append"></param>
        public static void SaveAs(this string? value, string fileName, bool append = false)
        {
            using var tw = new StreamWriter(fileName, append);
            tw.Write(value ?? string.Empty);
        }

        /// <summary>
        /// Save string content on disk
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fileName"></param>
        /// <param name="append"></param>
        public static Task SaveAsAsync(this string? value, string fileName, bool append = false)
        {
            using var tw = new StreamWriter(fileName, append);
            return tw.WriteAsync(value ?? string.Empty);
        }

        /// <summary>
        /// Save string content on disk
        /// </summary>
        /// <param name="value"></param>
        /// <param name="file"></param>
        /// <param name="append"></param>
        public static void SaveAs(this string? value, FileInfo file, bool append = false)
        {
            using var tw = new StreamWriter(file.FullName, append);
            tw.Write(value ?? string.Empty);
        }

        /// <summary>
        /// Save string content on disk
        /// </summary>
        /// <param name="value"></param>
        /// <param name="file"></param>
        /// <param name="append"></param>
        public static Task SaveAsAsync(this string? value, FileInfo file, bool append = false)
        {
            using var tw = new StreamWriter(file.FullName, append);
            return tw.WriteAsync(value ?? string.Empty);
        }
    }
}