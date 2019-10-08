namespace Maestria.Extensions.Test.``Syntax Extensions``
open System
open Maestria.Extensions
open NUnit.Framework
open FsUnit
open Maestria.Extensions.Test.Const

module NullIf =
    [<Test>]
    let ``Null if returning null``() =
        5.f.NullIf(5.f) |> should be Null
        5.0.NullIf(5.0) |> should be Null
        5.m.NullIf(5.m) |> should be Null
        DateTimeInput.NullIf(DateTimeInput) |> should be Null
        "Test".NullIf("Test") |> should be Null

    [<Test>]
    let ``Null if returning value``() =
        5.f.NullIf(1.f) |> should equal 5.f
        5.0.NullIf(1.0) |> should equal 5
        5.m.NullIf(1.m) |> should equal 5.m
        DateTimeInput.NullIf(DateTime.MinValue) |> should equal DateTimeInput
        "Test".NullIf("Different value") |> should equal "Test"

    [<Test>]
    let ``Null if returning null with floating point tolerance``() =
        let a: decimal = 0.00001m
        54.f.NullIf(54.000009f) |> should be Null
        54.0.NullIf(54.000009) |> should be Null
        54.m.NullIf(54.000009m, 0.00001m) |> should be Null // Decimal have precision comparasion and not work with tolerance by default

    [<Test>]
    let ``Null if returning vaule with floating point tolerance``() =
        54.f.NullIf(54.00001f) |> should equal 54.f
        54.0.NullIf(54.00001) |> should equal 54.f
        54.m.NullIf(54.00001m) |> should equal 54.f
        54.m.NullIf(54.000009m) |> should equal 54.m // Decimal have precision comparasion and not work with tolerance by default