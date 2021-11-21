module Authentication
open System
open Dapper.FSharp
open Dapper.FSharp.MSSQL
open System.Data.SqlClient
type Authentication = {
    AuthenticationType: string 
    AuthEmail: string
    UserID: Guid
}

let AuthenticationTable = table<Authentication>


let conn = new SqlConnection (Config.dbconn)
conn.Open()

type AuthenticationResult = AuthenticationError of string * string | AuthenticationSuccess of Authentication


let GetUserByAuthEmail authtype email = 
    let selectQuery = select { 
        for a in AuthenticationTable do 
        where(a.AuthEmail = email && a.AuthenticationType = authtype)
    }
    let queryResult = Database.Query conn.SelectAsync<Authentication> selectQuery
    queryResult.Result

let AuthenticateUser authtype email = 
    let QueryResult = (GetUserByAuthEmail authtype email) |> Seq.toList
    if QueryResult.IsEmpty then 
        AuthenticationError("Authentication Error", "User does not exist for this authentication scheme.")
    else if QueryResult.Length > 1 then
        AuthenticationError("Authentication Error", "Duplicate entries for credentials. This shouldn't happen.")
    else  
        AuthenticationSuccess QueryResult.Head
        
let insertAuth auth = 
    let query = insert { 
        into AuthenticationTable
        value auth 
    } 
    Database.Query conn.InsertAsync query