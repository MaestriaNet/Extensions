using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp
{
    public class SyntaxExtensionsTest
    {
        [Test]
        public void OutVar()
        {
            var executionPipelineResult = "abc123def"
                .OnlyNumbers()
                .OutVar(out var onlyNumbers)
                .Substring(0, 1);
            
            Assert.AreEqual("123", onlyNumbers);
            Assert.AreEqual("1", executionPipelineResult);
        }
    }
}