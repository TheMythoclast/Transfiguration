module TestTableTests
open NUnit.Framework
open System
open TestTable

let id = Guid.NewGuid() 
let newrow = { TestID = id; SomeColumn = "T"}
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
let ``New Row Should Be Created`` () = 
    createRow newrow |> AssertSuccess

[<Test>]
let ``New Row Should Be In DB`` () =   
    GetTestRowByID id |> AssertSuccess

[<Test>]
let ``X Delete Shouldn't Fail`` () = 
    DeleteTest id |> AssertSuccess

[<Test>]
let ``Z Deleted Row Shouldn't Be In DB`` () = 
    GetTestRowByID id |> AssertEmpty

[<Test>]
let ``Row should update properly`` () = 
    let id = Guid.NewGuid();
    let row = { TestID = id; SomeColumn = "Test"} 
    createRow row 
    UpdateTest { TestID = id; SomeColumn = "Braden"}
    GetTestRowByID id |> AssertSuccess