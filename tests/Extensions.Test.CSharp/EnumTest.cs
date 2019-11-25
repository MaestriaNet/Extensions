using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp
{
    public enum Color
    {
        [Display(Name = "Red color", Description = "Red color description")]
        Red,
        
        [DisplayName("Blue color")]
        [System.ComponentModel.Description("Blue color description")]
        Blue,
        
        [DisplayName("Green color from DisplayNameAttribute")]
        [System.ComponentModel.Description("Green color description from DescriptionAttribute")]
        [Display(Name = "Not used in this pipeline", Description = "Not used this pipeline")]
        Green
    }
    
    public class EnumTest
    {
        [TestCase(Color.Red, "Red color")]
        [TestCase(Color.Blue, "Blue color")]
        [TestCase(Color.Green, "Green color from DisplayNameAttribute")]
        public void GetDisplayName(Color value, string expected) => Assert.AreEqual(expected, value.GetDisplayName());

        [TestCase(Color.Red, "Red color description")]
        [TestCase(Color.Blue, "Blue color description")]
        [TestCase(Color.Green, "Green color description from DescriptionAttribute")]
        public void GetDescription(Color value, string expected) => Assert.AreEqual(expected, value.GetDescription());

        [Test]
        public void GetValues_GenericOverload() =>
            Assert.AreEqual(new[] {Color.Red, Color.Blue, Color.Green}, EnumExtensions.GetValues<Color>());
        
        [Test]
        public void GetValues() =>
            Assert.AreEqual(new[] {Color.Red, Color.Blue, Color.Green}, EnumExtensions.GetValues(typeof(Color)));
    }
}