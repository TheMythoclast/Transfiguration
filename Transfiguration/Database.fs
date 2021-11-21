module Database
open Config
open System.Data
open System.Data.SqlClient
open Dapper.FSharp
open Dapper.FSharp.MSSQL

// Not sure if I am going to use this.
let Query qtype query = 
    let conn = new SqlConnection (Config.dbconn)
    conn.OpenAsync() |> ignore
    let result = query |> qtype
    conn.CloseAsync() |> ignore
    result
let UpdateQuery query = 
    let conn = new SqlConnection (Config.dbconn)
    conn.OpenAsync() |> ignore
    let result = query |> conn.UpdateAsync
    conn.CloseAsync() |> ignore
    result

let InsertQuery query =
    let conn = new SqlConnection (Config.dbconn)
    conn.Open() |> ignore
    let result = query |> conn.InsertAsync
    conn.Close() |> ignore
    result

let DeleteQuery query =
    let conn = new SqlConnection (Config.dbconn)
    conn.Open() |> ignore
    let result = query |> conn.DeleteAsync
    conn.Close() |> ignore
    result

let SelectQuery query _ =
    let conn = new SqlConnection (Config.dbconn)
    conn.Open() |> ignore
    let result = query |> conn.SelectAsync<_>
    conn.Close() |> ignore
    result
    