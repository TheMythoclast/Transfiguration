module AuthTests
open NUnit.Framework
open Authentication
open DBResultTests
open System
[<SetUp>]
let Setup() = 
    ()

let newauth() = 
    { UserID = Guid.NewGuid(); AuthEmail = "me@mythoclast.me"; AuthenticationType="Test"}

[<Test>]
let ``Create New Authentication Shouldn't Throw Error`` () =
    newauth() |> NewAuthentication |> AssertSuccess

[<Test>]
let ``Deleting Authentication Should Work`` () = 
    let tauth = newauth() 
    tauth |> NewAuthentication |> ignore
    DeleteAuthentication tauth |> ignore
    GetUserByAuthEmail "Test" "me@mythoclast.me" |> AssertEmpty

[<Test>] 
let ``Auth Should Work Properly`` () = 
    newauth() |> NewAuthentication
    match AuthenticateUser "Test" "me@mythoclast.me" with 
        | AuthenticationError (e, x) -> 
            printfn "%s %s" e x
            Assert.Fail()
        | AuthenticationSuccess a -> Assert.Pass()