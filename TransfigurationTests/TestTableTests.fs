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

[<Test>]
let ``Should be created and findable`` () = 
    let newrow = { TestID = Guid.NewGuid(); SomeColumn = "T"}
    let rowid = newrow.TestID
    createRow newrow |> ignore
    (GetTestRowByID rowid) |> AssertSuccess

    