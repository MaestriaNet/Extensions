namespace Maestria.Extensions
{
    /// <summary>
    /// Syntax extensions to humanize reading source code
    /// </summary>
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Check value different of null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNotNull([NotNullWhen(true)] this object? value) => value != null;
    }
}