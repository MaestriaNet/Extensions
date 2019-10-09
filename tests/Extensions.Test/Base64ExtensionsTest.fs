module Maestria.Extensions.Test.``Base64 Extensions``
open System.Text
open FsUnit
open Maestria.Extensions
open NUnit.Framework

/// ===========================================
/// Diferentes tipos de dados para Convert
/// ===========================================
let PlainText = "Text to encode as Base64"
let PlainBytes = PlainText |> Encoding.UTF8.GetBytes

let Base64EncodedText = "VGV4dCB0byBlbmNvZGUgYXMgQmFzZTY0"
let Base64EncodedBytes = Base64EncodedText |> Encoding.UTF8.GetBytes

/// ===========================================
/// Encode tests
/// ===========================================
[<Test>]
let ``Encode string``() = PlainText
                          |> Base64Extensions.Encode
                          |> should equal Base64EncodedText

[<Test>]
let ``Encode bytes``() = PlainBytes
                          |> Base64Extensions.Encode
                          |> should equal Base64EncodedBytes

/// ===========================================
/// Decode tests
/// ===========================================
[<Test>]
let ``Decode string``() = Base64EncodedText
                          |> Base64Extensions.Decode
                          |> should equal PlainText

[<Test>]
let ``Decode bytes``() = Base64EncodedBytes
                          |> Base64Extensions.Decode
                          |> should equal PlainBytes