using Maestria.Extensions;
using Xunit;

namespace Extensions.Test.CSharp;

public class NullIfTest
{
    [Fact]
    public void NullIf_ReturningNull() => Assert.Null(Consts.Guid.NullIf(Consts.Guid));

    [Fact]
    public void NullIf_DontReturningNull() => Assert.Equal(Consts.Guid, Consts.Guid.NullIf(Consts.EmptyGuid));
}