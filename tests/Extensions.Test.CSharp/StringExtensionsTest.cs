using System.Linq;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp
{
    public class StringExtensionsTest
    {
        [Test]
        public void JoinArray()
        {
            var values = new[] {"my", "name", "is", "fabio"};
            Assert.AreEqual("mynameisfabio", values.Join(""));
            Assert.AreEqual("my name is fabio", values.Join(" "));
        }
        
        [Test]
        public void JoinEnumerable()
        {
            var values = new[] {"my", "name", "is", "fabio"}.AsEnumerable();
            Assert.AreEqual("mynameisfabio", values.Join(""));
            Assert.AreEqual("my name is fabio", values.Join(" "));
        }
    }
}