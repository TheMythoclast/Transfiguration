module Authorization
open System
open Dapper.FSharp
open Dapper.FSharp.MSSQL
open Database
open System.Data.SqlClient

type Authorization = { 
    UserID: Guid
    ClaimType: string 
    Claim: string 
}
let conn = new SqlConnection (Config.dbconn)
conn.Open()
let AuthorizationTable = table<Authorization> 

