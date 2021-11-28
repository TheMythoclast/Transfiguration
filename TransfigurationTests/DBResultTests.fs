[<AutoOpen>]
module DBResultTests
open GlobalTypes
open NUnit.Framework


let PrintError ((a,b): string * string) = 
    printf "%s: %s \n" <| a, b 
    

let ParseResults (result: ActionResult<'a>) = 
    match result with 
        | DatabaseError (errorname, errortext) -> (printfn "%s: %s"  errorname errortext)
        | ValidationError x ->  List.iter (fun (field, errormessage) -> printfn "%s: %s"  field errormessage) x
        | EmptyResult -> printfn "Empty Result"
        | OperationSuccess x -> printfn "%O" x

let AssertValidationError (result: ActionResult<'a>) =
    ParseResults result
    match result with 
        | ValidationError x -> Assert.Pass()
        | _ -> Assert.Fail()

let AssertDatabaseError (result: ActionResult<'a>) = 
    ParseResults result

    match result with 
        | DatabaseError (x, y) -> Assert.Pass()
        | _ -> Assert.Fail()
        
let AssertEmpty (result: ActionResult<'a>) =
    ParseResults result
    match result with 
        | EmptyResult -> Assert.Pass()
        | _ -> Assert.Fail()

let AssertSuccess (result: ActionResult<'a>) = 
    ParseResults result
    match result with 
        | OperationSuccess o -> Assert.Pass()
        | _ -> Assert.Fail()
