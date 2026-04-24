using Xunit;
using Maestria.Extensions;
using System;

namespace Maestria.Extensions.Test.CSharp;

public class IfNullOrEmptyTest
{
    [Fact]
    public void IfNullOrEmpty_EmptyStringTest() => Assert.True(Consts.EmptyString.IsNullOrEmpty());

    [Fact]
    public void IfNullOrEmpty_EmptyStringFailTest() => Assert.False(Consts.Text.IsNullOrEmpty());

    [Fact]
    public void IfNullOrEmpty_EmptyGuidTest() => Assert.True(Consts.EmptyGuid.IsEmpty());

    [Fact]
    public void IfNullOrEmpty_EmptyGuidFailTest() => Assert.False(Guid.NewGuid().IsEmpty());

    [Fact]
    public void IfNullOrEmpty_NullGuidTest() => Assert.True(Consts.NullGuid.IsNullOrEmpty());

    [Fact]
    public void IfNullOrEmpty_NullGuidFailTest() => Assert.False(((Guid?) Guid.NewGuid()).IsNullOrEmpty());

    // Tests from F# IfNullExtensionsTest
    [Fact]
    public void IfNull_DefaultDataTypeTest()
    {
        Assert.Equal("", "".IfNull("changed value"));
        Assert.Equal("test", "test".IfNull("changed value"));
        Assert.Equal("changed value", Consts.NullString.IfNull("changed value"));
        Assert.Equal(5, ((int?)5).IfNull(4));
        Assert.Equal(5, ((int?)null).IfNull(5));
    }

    [Fact]
    public void IfNullOrEmpty_StringTest()
    {
        Assert.Equal("changed value", "".IfNullOrEmpty("changed value"));
        Assert.Equal("  ", "  ".IfNullOrEmpty("changed value"));
        Assert.Equal("changed value", Consts.NullString.IfNullOrEmpty("changed value"));
    }

    [Fact]
    public void IfNullOrWhiteSpace_StringTest()
    {
        Assert.Equal("changed value", "".IfNullOrWhiteSpace("changed value"));
        Assert.Equal("changed value", "  ".IfNullOrWhiteSpace("changed value"));
        Assert.Equal("changed value", Consts.NullString.IfNullOrWhiteSpace("changed value"));
    }
}