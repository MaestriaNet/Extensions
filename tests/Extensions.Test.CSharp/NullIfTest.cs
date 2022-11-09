using Maestria.Extensions;
using NUnit.Framework;

namespace Extensions.Test.CSharp;

public class NullIfTest
{
    [Test]
    public void NullIf_ReturningNull() => Assert.Null(Consts.Guid.NullIf(Consts.Guid));

    [Test]
    public void NullIf_DontReturningNull() => Assert.AreEqual(Consts.Guid, Consts.Guid.NullIf(Consts.EmptyGuid));
}