namespace Maestria.Extensions.Test.``Collection Extensions``
open System
open System.Collections.Generic
open FsUnit
open NUnit.Framework
open Maestria.Extensions

module Const =
    let array = [|1; 2; 3; 4; 5|]
    let emptyArray = Array.empty<int>
    let nullList: List<int> = null

module Iterate =
    [<Test>]
    let ``Any collection for each execute``() = Const.array.Iterate(fun i -> (Array.contains i [|1;2;3;4;5|]) |> should be True) |> should equal Const.array

    [<Test>]
    let ``Empty collection for each execute``() = Const.emptyArray.Iterate(fun i -> i |> ignore) |> should equal Const.emptyArray

    [<Test>]
    let ``Null collection for each execute``() = (fun () -> MaestriaExtensions.Iterate(Const.nullList, fun i -> i |> ignore) |> should equal Const.nullList) |> should not' (throw typeof<NullReferenceException>)

module IsNullOrEmpty =
    [<Test>]
    let ``Any collection is empty check``() = Const.array.IsNullOrEmpty() |> should be False

    [<Test>]
    let ``Empty collection is empty check``() = Const.emptyArray.IsNullOrEmpty() |>  should be True

    [<Test>]
    let ``Null collection is empty check``() = Const.nullList.IsNullOrEmpty() |> should be True

module HasItems =
    [<Test>]
    let ``Any collection has items check``() = Const.array.HasItems()  |> should be True

    [<Test>]
    let ``Empty collection has items check``() = Const.emptyArray.HasItems()  |> should be False

    [<Test>]
    let ``Null collection has items check``() = Const.nullList.HasItems()  |> should be False