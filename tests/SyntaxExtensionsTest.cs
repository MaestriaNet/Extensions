using System;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp;

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

    [Test]
    public void LimitMaxAtTest()
    {
        Assert.AreEqual(10, 10.LimitMaxAt(15));
        Assert.AreEqual(15, 15.LimitMaxAt(15));
        Assert.AreEqual(15, 20.LimitMaxAt(15));
    }

    [Test]
    public void LimitMinAtTest()
    {
        Assert.AreEqual(15, 10.LimitMinAt(15));
        Assert.AreEqual(15, 15.LimitMinAt(15));
        Assert.AreEqual(20, 20.LimitMinAt(15));
    }

    // Tests from F# SyntaxExtensionsTest - In
    [TestCase(MyColor.Red, new[] { MyColor.Red, MyColor.Green, MyColor.Blue })]
    [TestCase(MyColor.Green, new[] { MyColor.Red, MyColor.Green, MyColor.Blue })]
    [TestCase(MyColor.Blue, new[] { MyColor.Red, MyColor.Green, MyColor.Blue })]
    public void EnumInArrayGroup(MyColor value, MyColor[] values)
    {
        Assert.IsTrue(value.In(values));
    }

    [TestCase(MyColor.Yellow, new[] { MyColor.Red, MyColor.Green, MyColor.Blue })]
    public void EnumNotInArrayGroup(MyColor value, MyColor[] values)
    {
        Assert.IsFalse(value.In(values));
    }

    [TestCase(5, new[] { 5, 10, 15 })]
    [TestCase(10, new[] { 5, 10, 15 })]
    [TestCase(15, new[] { 5, 10, 15 })]
    public void ValueInArrayGroup(int value, int[] values)
    {
        Assert.IsTrue(value.In(values));
    }

    [TestCase(4, new[] { 5, 10, 15 })]
    [TestCase(8, new[] { 5, 10, 15 })]
    [TestCase(12, new[] { 5, 10, 15 })]
    [TestCase(16, new[] { 5, 10, 15 })]
    public void ValueNotInArrayGroup(int value, int[] values)
    {
        Assert.IsFalse(value.In(values));
    }

    // Between tests
    [TestCase("2019-07-23", "2019-07-20", "2019-07-25")]
    [TestCase("2019-07-23", "2019-07-20", "2019-07-23")]
    [TestCase("2019-07-23", "2019-07-23", "2019-07-25")]
    public void DateBetweenInterval(DateTime value, DateTime min, DateTime max)
    {
        Assert.IsTrue(value.Between(min, max));
    }

    [TestCase("2019-07-23", "2019-07-21", "2019-07-22")]
    [TestCase("2019-07-23", "2019-07-24", "2019-07-25")]
    public void DateNotBetweenInterval(DateTime value, DateTime starting, DateTime ending)
    {
        Assert.IsFalse(value.Between(starting, ending));
    }

    [TestCase(10, 5, 15)]
    [TestCase(10, 10, 15)]
    [TestCase(10, 5, 10)]
    public void ValueBetweenInterval(int value, int min, int max)
    {
        Assert.IsTrue(value.Between(min, max));
    }

    [TestCase(10, 11, 15)]
    [TestCase(10, 5, 9)]
    public void ValueNotBetweenInterval(int value, int starting, int ending)
    {
        Assert.IsFalse(value.Between(starting, ending));
    }
}