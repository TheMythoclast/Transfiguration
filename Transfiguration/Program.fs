// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open TestTable
open Authentication
open User
// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let TestAuth = { AuthenticationType = "Windows"; AuthEmail = "bradenmacbeth@outlook.com"; UserID = Guid.NewGuid() }
    //insertAuth TestAuth
    let a = AuthenticateUser "Windows" "bradenmacbeth@outlook.com"
    match a with 
        | AuthenticationSuccess o -> insertUser { UserID = o.UserID; FirstName = "Braden"; LastName = "MacBeth"; Email = "bradenmacbeth@outlook.com"}
        | AuthenticationError (a, b) -> printfn "Fuck"
    let message = from "F#" // Call the function
    printfn "Hello world %s" message
    0 // return an integer  exit code