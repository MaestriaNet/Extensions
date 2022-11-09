using System;

namespace Maestria.Extensions
{

    public static partial class MaestriaExtensions
    {

        /// <summary>
        /// Gets the most inner (deepest) exception of a given Exception object
        /// </summary>
        /// <param name="value">Source Exception</param>
        /// <returns></returns>
        public static Exception? GetMostInner(this Exception? value) =>
            value?.InnerException == null ? value : value.InnerException.GetMostInner();
    }
}