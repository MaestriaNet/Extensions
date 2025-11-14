using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Maestria.Extensions.Test.CSharp;

public enum Color
{
    [Display(Name = "Red color", Description = "Red color description")]
    Red,

    // [DisplayName("Blue color")]
    [System.ComponentModel.Description("Blue color description")]
    Blue,

    // [DisplayName("Green color from DisplayNameAttribute")]
    [System.ComponentModel.Description("Green color description from DescriptionAttribute")]
    [Display(Name = "Green color", Description = "Not used this pipeline")]
    Green
}

public class EnumTest
{
    [Theory]
    [InlineData(Color.Red, "Red color")]
    [InlineData(Color.Blue, "Blue")]
    [InlineData(Color.Green, "Green color")]
    public void GetDisplayName(Color value, string expected) => Assert.Equal(expected, value.GetDisplayName());

    [Theory]
    [InlineData(Color.Red, "Red color description")]
    [InlineData(Color.Blue, "Blue color description")]
    [InlineData(Color.Green, "Green color description from DescriptionAttribute")]
    public void GetDescription(Color value, string expected) => Assert.Equal(expected, value.GetDescription());

    [Fact]
    public void GetValues_GenericOverload() =>
        Assert.Equal(new[] {Color.Red, Color.Blue, Color.Green}, EnumExtensions.GetValues<Color>());

    [Fact]
    public void GetValues()
    {
        var values = EnumExtensions.GetValues(typeof(Color));
        Assert.Equal(Color.Red, values[0]);
        Assert.Equal(Color.Blue, values[1]);
        Assert.Equal(Color.Green, values[2]);
    }
}