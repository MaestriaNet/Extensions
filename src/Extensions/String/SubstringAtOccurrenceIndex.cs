using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{

    /// <summary>
    /// Split <paramref name="value"/> by <paramref name="separator"/> and return <paramref name="occurrenceIndex"/> occurrence index. This is a safe method and returns null when then <paramref name="occurrenceIndex"/> was not satisfied.
    /// </summary>
    /// <param name="value">Full text</param>
    /// <param name="separator">Find text pattern</param>
    /// <param name="occurrenceIndex"></param>
    /// <param name="autoTrim">Apply trim on result</param>
    /// <param name="options"></param>
    /// <returns>If input is null value, returns is empty string</returns>
    public static string SubstringAtOccurrenceIndex(this string? value, string separator, int occurrenceIndex, bool autoTrim = true, StringSplitOptions options = StringSplitOptions.None)
    {
        if (value == null || occurrenceIndex < 0)
            return string.Empty;
        var splited = value.Split(new[] { separator }, options);
        if (occurrenceIndex >= splited.Length)
            return string.Empty;
        return autoTrim ? splited[occurrenceIndex].Trim() : splited[occurrenceIndex];
    }
}