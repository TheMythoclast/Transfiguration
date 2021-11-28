module Authentication
open System
open Dapper.FSharp
open Dapper.FSharp.MSSQL


let AuthenticationTable = table<Authentication>



type AuthenticationResult = AuthenticationError of string * string | AuthenticationSuccess of Authentication


let GetUserByAuthEmail authtype email = 
    let selectQuery = select { 
        for a in AuthenticationTable do 
        where(a.AuthEmail = email && a.AuthenticationType = authtype)
    }
    Database.SelectQuery<Authentication> selectQuery
    

let AuthenticateUser authtype email = 
    let qresult = (GetUserByAuthEmail authtype email)
    match qresult with 
        | OperationSuccess x -> 
            if x.IsEmpty then 
                AuthenticationError("Authentication Error", "User does not exist for this authentication scheme.")
            else if x.Length > 1 then
                AuthenticationError("Authentication Error", "Duplicate entries for credentials. This shouldn't happen.")
            else  
                AuthenticationSuccess x.Head
        | _ -> AuthenticationError("Authentication Error", "Wat")


let NewAuthentication auth = 
    let query = insert { 
        into AuthenticationTable
        value auth 
    } 
    query |> Database.InsertQuery

//This is for testing purposes only, won't be in the final API... hopefully. 
let DeleteAuthentication auth = 
    let query = delete { 
        for z in AuthenticationTable do
            where (z.AuthEmail = auth.AuthEmail && z.AuthenticationType = z.AuthenticationType) 
    } 
    query |> Database.DeleteQuery