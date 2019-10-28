namespace Maestria.Extensions.Test.``If Null Extensions``
open System
open Maestria.Extensions
open NUnit.Framework
open FsUnit
open Maestria.Extensions.Test.Const
open Maestria.Extensions.Test.Internal

module Default =

    [<Test>]
    let ``Default data type test``() =
        "".IfNull("changed value") |> should equal ""
        "test".IfNull("changed value") |> should equal "test"
        NullString.IfNull("changed value") |> should equal "changed value"
        (new Nullable<int>(5)).IfNull(4) |> should equal 5
        (new Nullable<int>()).IfNull(5) |> should equal 5

module String =
    [<Test>]
    let ``If null or empty``() =
        "".IfNullOrEmpty("changed value") |> should equal "changed value"
        "  ".IfNullOrEmpty("changed value") |> should equal "  "
        NullString.IfNullOrEmpty("changed value") |> should equal "changed value"

    [<Test>]
    let ``If null or whiteSpace``() =
        "".IfNullOrWhiteSpace("changed value") |> should equal "changed value"
        "  ".IfNullOrWhiteSpace("changed value") |> should equal "changed value"
        NullString.IfNullOrWhiteSpace("changed value") |> should equal "changed value"