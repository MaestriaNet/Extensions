using System;
using System.Text;
using Maestria.Extensions.Settings;

namespace Maestria.Extensions;

// Model
public partial class MaestriaExtensionsSettings
{
    /// <summary>
    /// Float and double equality tolerance. When the comparison difference is lower than the tolerance, the result is considered equal. Default is 0.00001f.
    /// </summary>
    public float FloatingPointTolerance { get; set; } = 0.00001f;
    
    /// <summary>
    /// Encoding default to use in internal methods when not specified.
    /// </summary>
    public Encoding DefaultEncoding { get; set; } = Encoding.UTF8;
}

// Factory
public partial class MaestriaExtensionsSettings
{
    static MaestriaExtensionsSettings()
    {
        Builder = new MaestriaExtensionsSettingsBuilder(Properties);
    }
    
    private static readonly MaestriaExtensionsSettingsBuilder Builder;
    
    public static MaestriaExtensionsSettings Properties { get; } = new();
    
    public static void Configure(Action<MaestriaExtensionsSettingsBuilder> cfg) => cfg(Builder);
}