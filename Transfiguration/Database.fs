module Database
open Config
open System.Data
open System.Data.SqlClient
open Dapper.FSharp
open Dapper.FSharp.MSSQL

// Not sure if I am going to use this.
let UpdateQuery query = 
    let conn = new SqlConnection (Config.dbconn)
    conn.OpenAsync() |> ignore
    let result = query |> conn.UpdateAsync
    conn.CloseAsync() |> ignore
    result
