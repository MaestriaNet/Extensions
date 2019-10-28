namespace Maestria.Extensions.Test.``Null If Extensions``
open System
open Maestria.Extensions
open NUnit.Framework
open FsUnit
open Maestria.Extensions.Test.Const
open Maestria.Extensions.Test.Internal
open TestUtil

module Default =

    [<Test>]
    let ``Should be null``() =
        DateTimeInput.NullIf(DateTimeInput) |> should be Null
        (5).NullIf(5) |> should be Null
        (5).NullIfIn(4, 5, 6) |> should be Null
        (5).NullIfBetween(4, 6) |> should be Null
        {Name = "test"}.NullIf({Name = "test"}) |> should be Null

    [<Test>]
    let ``Should have value``() =
        DateTimeInput.NullIf(DateTime.MinValue) |> should equal DateTimeInput
        (3).NullIf(5) |> should equal 3
        (3).NullIfIn(4, 5, 6) |> should equal 3
        (3).NullIfBetween(4, 6) |> should equal 3
        {Name = "test"}.NullIf({Name = "test-2"}) |> should equal {Name = "test"}

module ``Floating point tolerance`` =
    [<Test>]
    let ``Should be null``() =
        54.f.NullIf(54.000009f) |> should be Null
        54.0.NullIf(54.000009) |> should be Null
        54.m.NullIf(54.000009m, 0.00001m) |> should be Null // Decimal have precision comparasion and not work with tolerance by default

    [<Test>]
    let ``Should be null nullables types``() =
        (new Nullable<float32>(54.f)).NullIf(new Nullable<float32>(54.000009f)) |> should be Null
        (new Nullable<double>(54.0)).NullIf(new Nullable<double>(54.000009)) |> should be Null
        (new Nullable<decimal>(54.m)).NullIf(new Nullable<decimal>(54.000009m), 0.00001m) |> should be Null // Decimal have precision comparasion and not work with tolerance by default

    [<Test>]
    let ``Should have value``() =
        54.f.NullIf(54.00001f) |> should equal 54.f
        54.0.NullIf(54.00001) |> should equal 54.f
        54.m.NullIf(54.00001m) |> should equal 54.f
        54.m.NullIf(54.000009m) |> should equal 54.m // Decimal have precision comparasion and not work with tolerance by default

    [<Test>]
    let ``Should have value nullables types``() =
        (new Nullable<float32>(54.f)).NullIf(new Nullable<float32>(54.00001f)) |> should equal 54.f
        (new Nullable<double>(54.0)).NullIf(new Nullable<double>(54.00001)) |> should equal 54.f
        (new Nullable<decimal>(54.m)).NullIf(new Nullable<decimal>(54.00001m)) |> should equal 54.f
        (new Nullable<decimal>(54.m)).NullIf(new Nullable<decimal>(54.000009m)) |> should equal 54.m // Decimal have precision comparasion and not work with tolerance by default

module ``String`` =
    [<Test>]
    let ``If Empty``() =
        "".NullIfEmpty() |> should be Null
        "test".NullIfEmpty() |> should equal "test"

    [<Test>]
    let ``If White Space``() =
        "  ".NullIfWhiteSpace() |> should be Null
        "test".NullIfWhiteSpace() |> should equal "test"

    [<Test>]
    let ``Ignore case``() =
        "test".NullIf("test") |> should be Null
        "test".NullIf("TEST") |> should equal "test"
        "test".NullIf("test", false) |> should be Null
        "test".NullIf("TEST", false) |> should equal "test"
        "test".NullIf("test", true) |> should be Null
        "test".NullIf("TEST", true) |> should be Null
        "test".NullIf(NullString) |> should equal "test"
        NullString.NullIf(NullString) |> should be null