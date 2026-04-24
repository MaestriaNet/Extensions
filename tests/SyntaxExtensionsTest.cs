using System;
using Xunit;

namespace Maestria.Extensions.Test.CSharp;

public class SyntaxExtensionsTest
{
    [Fact]
    public void OutVar()
    {
        var executionPipelineResult = "abc123def"
            .OnlyNumbers()
            .OutVar(out var onlyNumbers)
            .Substring(0, 1);

        Assert.Equal("123", onlyNumbers);
        Assert.Equal("1", executionPipelineResult);
    }

    [Fact]
    public void LimitMaxAtTest()
    {
        Assert.Equal(10, 10.LimitMaxAt(15));
        Assert.Equal(15, 15.LimitMaxAt(15));
        Assert.Equal(15, 20.LimitMaxAt(15));
    }

    [Fact]
    public void LimitMinAtTest()
    {
        Assert.Equal(15, 10.LimitMinAt(15));
        Assert.Equal(15, 15.LimitMinAt(15));
        Assert.Equal(20, 20.LimitMinAt(15));
    }

    // Tests from F# SyntaxExtensionsTest - In
    [Theory]
    [InlineData(MyColor.Red, new[] { MyColor.Red, MyColor.Green, MyColor.Blue })]
    [InlineData(MyColor.Green, new[] { MyColor.Red, MyColor.Green, MyColor.Blue })]
    [InlineData(MyColor.Blue, new[] { MyColor.Red, MyColor.Green, MyColor.Blue })]
    public void EnumInArrayGroup(MyColor value, MyColor[] values)
    {
        Assert.True(value.In(values));
    }

    [Theory]
    [InlineData(MyColor.Yellow, new[] { MyColor.Red, MyColor.Green, MyColor.Blue })]
    public void EnumNotInArrayGroup(MyColor value, MyColor[] values)
    {
        Assert.False(value.In(values));
    }

    [Theory]
    [InlineData(5, new[] { 5, 10, 15 })]
    [InlineData(10, new[] { 5, 10, 15 })]
    [InlineData(15, new[] { 5, 10, 15 })]
    public void ValueInArrayGroup(int value, int[] values)
    {
        Assert.True(value.In(values));
    }

    [Theory]
    [InlineData(4, new[] { 5, 10, 15 })]
    [InlineData(8, new[] { 5, 10, 15 })]
    [InlineData(12, new[] { 5, 10, 15 })]
    [InlineData(16, new[] { 5, 10, 15 })]
    public void ValueNotInArrayGroup(int value, int[] values)
    {
        Assert.False(value.In(values));
    }

    // Between tests
    [Theory]
    [InlineData("2019-07-23", "2019-07-20", "2019-07-25")]
    [InlineData("2019-07-23", "2019-07-20", "2019-07-23")]
    [InlineData("2019-07-23", "2019-07-23", "2019-07-25")]
    public void DateBetweenInterval(DateTime value, DateTime min, DateTime max)
    {
        Assert.True(value.Between(min, max));
    }

    [Theory]
    [InlineData("2019-07-23", "2019-07-21", "2019-07-22")]
    [InlineData("2019-07-23", "2019-07-24", "2019-07-25")]
    public void DateNotBetweenInterval(DateTime value, DateTime starting, DateTime ending)
    {
        Assert.False(value.Between(starting, ending));
    }

    [Theory]
    [InlineData(10, 5, 15)]
    [InlineData(10, 10, 15)]
    [InlineData(10, 5, 10)]
    public void ValueBetweenInterval(int value, int min, int max)
    {
        Assert.True(value.Between(min, max));
    }

    [Theory]
    [InlineData(10, 11, 15)]
    [InlineData(10, 5, 9)]
    public void ValueNotBetweenInterval(int value, int starting, int ending)
    {
        Assert.False(value.Between(starting, ending));
    }
}