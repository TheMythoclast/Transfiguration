module AuthTests
open NUnit.Framework
open Authentication
open DBResultTests
open System
[<SetUp>]
let Setup() = 
    ()

[<Test>]
let ``Insert test`` () =
    NewAuthentication { UserID = Guid.NewGuid(); AuthenticationType = "Windows"; AuthEmail="me@mythoclast.me"} |> AssertSuccess
[<Test>]
let ``Hello`` () = 
    DeleteAuthentication { UserID = Guid.NewGuid(); AuthenticationType = "Windows"; AuthEmail="me@mythoclast.me"}  |> AssertSuccess