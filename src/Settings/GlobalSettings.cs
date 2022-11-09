using System;
using Maestria.Extensions.Settings;

namespace Maestria.Extensions;

public static class GlobalSettings
{
    static GlobalSettings()
    {
        Builder = new MaestriaExtensionSettingsBuilder(Properties);
    }

    private static readonly MaestriaExtensionSettingsBuilder Builder;
    public static MaestriaExtensionSettings Properties { get; } = new MaestriaExtensionSettings();

    public static void Configure(Action<MaestriaExtensionSettingsBuilder> cfg) => cfg(Builder);
}