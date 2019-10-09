module Maestria.Extensions.Test.``Hash Extensions``
open System
open NUnit.Framework
open FsUnit
open Maestria.Extensions
open Maestria.Extensions

/// ===========================================
/// Input values
/// ===========================================

let InputValue = "Value to cryptography test"

/// ===========================================
/// Expected values
/// ===========================================
let Md5Expected = "930fe80be1c6a5b5bfc49ab91727bb91"
let Sha1Expected = "a9c1f880a83374094f4242c0b72e1bf888504983"
let Sha256Expected = "0c3854f97ec73fbcafe048f78e2f2a88c06d335a67220e004f1e82e7bb8fee69"
let Sha384Expected = "25c8c1a053eff04f331d43434fcffe022a2747ba3d61c2406468d9cdfd6e329115f814bf3d6e2d9ddeb2cf1964cd1f89"
let Sha512Expected = "782be31c425eff35b3028fc0a2b3535392605821467c713370f16fa96c94eb07309dc19575d819b11fe42d387d211c2caf404d2b46ee9cfe0333dd96bb6a3029"


[<Test>]
let ``MD5 hash test``() = InputValue.GetHashMd5() |> should equal Md5Expected

[<Test>]
let ``SHA1 hash test``() = InputValue.GetHashSha1() |> should equal Sha1Expected

[<Test>]
let ``SHA256 hash test``() = InputValue.GetHashSha256() |> should equal Sha256Expected

[<Test>]
let ``SHA384 hash test``() = InputValue.GetHashSha384() |> should equal Sha384Expected

[<Test>]
let ``SHA512 hash test``() = InputValue.GetHashSha512() |> should equal Sha512Expected

[<Test>]
let ``Null not suported exception``() = (fun () -> HashExtensions.ComputeHash(HashAlgorithm.Md5, null) |> ignore)
                                        |> should throw typeof<ArgumentNullException>