using System;

namespace Maestria.Extensions
{

    public static partial class MaestriaExtensions
    {

        /// <summary>
        /// Gets the most inner (deepest) exception of a given Exception object
        /// </summary>
        /// <param name="ex">Source Exception</param>
        /// <returns></returns>
        public static Exception GetMostInner(this Exception ex) =>
            ex.InnerException == null ? ex : ex.InnerException.GetMostInner();
    }
}