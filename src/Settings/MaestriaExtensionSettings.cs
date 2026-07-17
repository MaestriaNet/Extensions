using System.Text;

namespace Maestria.Extensions.Settings;

public class MaestriaExtensionSettings
{
    /// <summary>
    /// Float and double equality, greater than and smallest than tolerance ignore to compare. Default is 0.00001f
    /// </summary>
    public float FloatAndDoubleTolerance { get; set; } = 0.00001f;
    
    /// <summary>
    /// Encoding default to use in internal methods when not specified.
    /// </summary>
    public Encoding DefaultEncoding { get; set; } = Encoding.UTF8;
}