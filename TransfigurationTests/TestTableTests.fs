module TestTableTests
open NUnit.Framework
open System
open TestTable
[<SetUp>]
let Setup () =
    ()

[<Test>]
let ``Random UID Should Return Empty `` () =    
    AssertEmpty (testSelect <| Guid.NewGuid())
        
[<Test>]
let ``TestTable Should Return Results `` () = 
    getTests |> AssertSuccess
