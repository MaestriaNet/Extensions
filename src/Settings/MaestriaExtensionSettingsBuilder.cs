namespace Maestria.Extensions.Settings;

public class MaestriaExtensionSettingsBuilder
{
    private readonly MaestriaExtensionSettings _instance;

    public MaestriaExtensionSettingsBuilder(MaestriaExtensionSettings instance)
    {
        _instance = instance;
    }

    public MaestriaExtensionSettingsBuilder FloatAndDoubleTolerance(float value)
    {
        _instance.FloatAndDoubleTolerance = value;
        return this;
    }
}