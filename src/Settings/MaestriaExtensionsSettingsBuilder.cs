using System.Text;

namespace Maestria.Extensions.Settings;

public class MaestriaExtensionsSettingsBuilder(MaestriaExtensionsSettings instance)
{
    public MaestriaExtensionsSettingsBuilder FloatingPointTolerance(float value)
    {
        instance.FloatingPointTolerance = value;
        return this;
    }
    
    public MaestriaExtensionsSettingsBuilder DefaultEncoding(Encoding value)
    {
        instance.DefaultEncoding = value;
        return this;
    }
}