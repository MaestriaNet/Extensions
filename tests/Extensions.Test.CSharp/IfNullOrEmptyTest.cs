using Maestria.Extensions;
using System;
using Xunit;

namespace Extensions.Test.CSharp;

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
}