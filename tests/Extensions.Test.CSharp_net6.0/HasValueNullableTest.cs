using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp;

public class HasValueNullableTest
{
    [Test]
    public void HasValue()
    {
        var value = GetData();
        var teste = value.ReferenciaCaixaOrigem.HasValue() ? value.ReferenciaCaixaOrigem.ToLower() : "";
        var teste2 = value.ReferenciaCaixaOrigem.EmptyIfNull().ToLower();
        // var teste3 = value.ReferenciaCaixaOrigem.ToLower();
        Assert.IsNotNull(value);

        var teste4 = value.ReferenciaCaixaOrigem.EmptyIf("");
    }

    public VendaChannelModel GetData() => new VendaChannelModel("", "", null, null);
}

public record struct VendaChannelModel(
    string ReferenciaOrigem,
    string ReferenciaLojaOrigem,
    string? ReferenciaClienteOrigem,
    string? ReferenciaCaixaOrigem);
