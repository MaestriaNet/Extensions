#if !NET5_0_OR_GREATER
using System;

namespace Maestria.Extensions.Attributes;

/// <summary>
/// Fake attribute used to by pass .net 5 feature at .net standard build
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal sealed class NotNullWhenFakeAttribute : Attribute
{
    public NotNullWhenFakeAttribute(bool returnValue)
    {
    }
}

#endif