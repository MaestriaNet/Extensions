namespace Maestria.Extensions.Test.``Syntax Extensions``
open System
open System

open Maestria.Extensions.Test.Internal.TestUtil
open Maestria.Extensions
open NUnit.Framework
open FsUnit

module In =
    [<TestCase(10, [|5; 10; 35|])>]
    [<TestCase(10.0, [|5.0; 10.0; 35.0|])>]
    let ``Value in array group2``<'a> (value: 'a, values: 'a array) =
        value.In(values) |> should be True

    [<Test>]
    let ``Value in array group``() =
        MyColor.Red.In(MyColor.Red, MyColor.Green, MyColor.Blue) |> should be True
        (10).In(5, 10, 35) |> should be True

    [<Test>]
    let ``Value not in array group``() =
        MyColor.Yellow.In(MyColor.Red, MyColor.Green, MyColor.Blue) |> should be False
        (11).In(5, 10, 35) |> should be False

module Between =
    [<TestCase("2019-07-23", "2019-07-20", "2019-07-25")>]
    [<TestCase("2019-07-23", "2019-07-20", "2019-07-23")>]
    [<TestCase("2019-07-23", "2019-07-23", "2019-07-25")>]
    let ``Date between interval``(value: DateTime, min: DateTime, max: DateTime) =
        value.Between(min, max) |> should be True

    [<TestCase("2019-07-23", "2019-07-21", "2019-07-22")>]
    [<TestCase("2019-07-23", "2019-07-24", "2019-07-25")>]
    let ``Date not between interval``(value: DateTime, starting: DateTime, ending: DateTime) =
        value.Between(starting, ending) |> should be False

    [<TestCase(10, 5, 15)>]
    [<TestCase(10, 10, 15)>]
    [<TestCase(10, 5, 10)>]
    let ``Value between interval``(value, min, max) =
        value.Between(min, max) |> should be True

    [<TestCase(10, 11, 15)>]
    [<TestCase(10, 5, 9)>]
    let ``Value not between interval``(value, starting, ending) =
        value.Between(starting, ending) |> should be False