using NUnit.Framework;
using Maestria.Extensions;
using System;

namespace Maestria.Extensions.Test.CSharp;

public class IfNullOrEmptyTest
{
    [Test]
    public void IfNullOrEmpty_EmptyStringTest() => Assert.True(Consts.EmptyString.IsNullOrEmpty());

    [Test]
    public void IfNullOrEmpty_EmptyStringFailTest() => Assert.False(Consts.Text.IsNullOrEmpty());

    [Test]
    public void IfNullOrEmpty_EmptyGuidTest() => Assert.True(Consts.EmptyGuid.IsEmpty());

    [Test]
    public void IfNullOrEmpty_EmptyGuidFailTest() => Assert.False(Guid.NewGuid().IsEmpty());

    [Test]
    public void IfNullOrEmpty_NullGuidTest() => Assert.True(Consts.NullGuid.IsNullOrEmpty());

    [Test]
    public void IfNullOrEmpty_NullGuidFailTest() => Assert.False(((Guid?) Guid.NewGuid()).IsNullOrEmpty());

    // Tests from F# IfNullExtensionsTest
    [Test]
    public void IfNull_DefaultDataTypeTest()
    {
        Assert.AreEqual("", "".IfNull("changed value"));
        Assert.AreEqual("test", "test".IfNull("changed value"));
        Assert.AreEqual("changed value", Consts.NullString.IfNull("changed value"));
        Assert.AreEqual(5, ((int?)5).IfNull(4));
        Assert.AreEqual(5, ((int?)null).IfNull(5));
    }

    [Test]
    public void IfNullOrEmpty_StringTest()
    {
        Assert.AreEqual("changed value", "".IfNullOrEmpty("changed value"));
        Assert.AreEqual("  ", "  ".IfNullOrEmpty("changed value"));
        Assert.AreEqual("changed value", Consts.NullString.IfNullOrEmpty("changed value"));
    }

    [Test]
    public void IfNullOrWhiteSpace_StringTest()
    {
        Assert.AreEqual("changed value", "".IfNullOrWhiteSpace("changed value"));
        Assert.AreEqual("changed value", "  ".IfNullOrWhiteSpace("changed value"));
        Assert.AreEqual("changed value", Consts.NullString.IfNullOrWhiteSpace("changed value"));
    }
}