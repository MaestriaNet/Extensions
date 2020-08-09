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

        [Test]
        public void SubstringBeforeFirstOccurrence_Default()
        {
            Assert.AreEqual("part 1", "part 1-part 2".SubstringBeforeFirstOccurrence("-"));
            Assert.AreEqual("part 1", "part 1-part 2".SubstringBeforeFirstOccurrence("-"));
            Assert.AreEqual("part 1", "part 1-part 2-part 3".SubstringBeforeFirstOccurrence("-"));
            Assert.Null("part 1".SubstringBeforeFirstOccurrence("x"));
        }

        [Test]
        public void SubstringBeforeFirstOccurrence_DisabledTrim()
        {
            Assert.AreEqual("part 1 ", "part 1 - part 2".SubstringBeforeFirstOccurrence("-", false));
            Assert.AreEqual("part 1 ", "part 1 - part 2".SubstringBeforeFirstOccurrence("-", false));
            Assert.AreEqual("part 1 ", "part 1 - part 2-part 3".SubstringBeforeFirstOccurrence("-", false));
            Assert.Null("part 1".SubstringBeforeFirstOccurrence("x", false));
        }

        [Test]
        public void SubstringAfterFirstOccurrence_Default()
        {
            Assert.AreEqual("part 2", "part 1-part 2".SubstringAfterFirstOccurrence("-"));
            Assert.AreEqual("part 2", "part 1-part 2".SubstringAfterFirstOccurrence("-"));
            Assert.AreEqual("part 2-part 3", "part 1-part 2-part 3".SubstringAfterFirstOccurrence("-"));
            Assert.Null("part 1".SubstringAfterFirstOccurrence("x"));
        }

        [Test]
        public void SubstringAfterFirstOccurrence_DisabledTrim()
        {
            Assert.AreEqual(" part 2", "part 1 - part 2".SubstringAfterFirstOccurrence("-", false));
            Assert.AreEqual(" part 2", "part 1 - part 2".SubstringAfterFirstOccurrence("-", false));
            Assert.AreEqual(" part 2 - part 3", "part 1 - part 2 - part 3".SubstringAfterFirstOccurrence("-", false));
            Assert.Null("part 1".SubstringAfterFirstOccurrence("x", false));
        }
    }
}