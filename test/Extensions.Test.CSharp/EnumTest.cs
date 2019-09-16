using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;

namespace Tests
{
    public enum Teste
    {
        [Display(Name = "aaa", Description = "aaaa")]
        [DisplayName("bbb")]
        [System.ComponentModel.Description("xxxx")]
        Vermelho,
        Azul
    }
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}