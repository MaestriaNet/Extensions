namespace Maestria.Extensions.Settings
{
    public class MaestriaExtensionSettings
    {
        /// <summary>
        /// Float and double equality, greater then and smallest then tolerance ignore to compare. Default is 0.00001f
        /// </summary>
        public float FloatAndDoubleTolerance { get; set; } = 0.00001f;
    }
}