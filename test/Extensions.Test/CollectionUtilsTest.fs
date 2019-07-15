module Biofa.Framework.Utils.Test.``Collection Extensions``
open System
open System.Collections.Generic
open FsUnit
open NUnit.Framework
open Maestria.Extensions

let array = [|1; 2; 3; 4; 5|]
let emptyArray = Array.empty<int>
let nullList: List<int> = null

module ForEach =
    [<Test>]
    let ``Any collection for each execute``() = array.ForEach(fun i -> (Array.contains i [|1;2;3;4;5|]) |> should be True)

    [<Test>]
    let ``Empty collection for each execute``() = emptyArray.ForEach(fun i -> i |> ignore)

    [<Test>]
    let ``Null collection for each execute``() = (fun () -> CollectionExtensions.ForEach(nullList, fun i -> i |> ignore)) |> should not' (throw typeof<NullReferenceException>)

module IsNullOrEmpty =
    [<Test>]
    let ``Any collection is empty check``() = array.IsNullOrEmpty() |> should be False

    [<Test>]
    let ``Empty collection is empty check``() = emptyArray.IsNullOrEmpty() |>  should be True

    [<Test>]
    let ``Null collection is empty check``() = nullList.IsNullOrEmpty() |> should be True

module HasItems =
    [<Test>]
    let ``Any collection has items check``() = array.HasItems()  |> should be True

    [<Test>]
    let ``Empty collection has items check``() = emptyArray.HasItems()  |> should be False

    [<Test>]
    let ``Null collection has items check``() = nullList.HasItems()  |> should be False