module User
open Authentication
open Database
open Dapper.FSharp
open Dapper.FSharp.MSSQL
open System
open System.Data.SqlClient

let conn = new SqlConnection(Config.dbconn)
conn.Open()



let UserTable = table<User>

let insertUser user = 
    let insertQuery = insert { 
        into UserTable
        value user
    }
    Database.Query conn.InsertAsync insertQuery 
    ()

let GetUser userid = 
    let selectQuery = select { 
        for u in UserTable do 
            where(u.UserID = userid)
    }
    let qresult = Database.Query conn.SelectAsync<User> selectQuery
    (qresult.Result |> Seq.toList).Head 
let UpdateUser user = 
    let updateQuery = update { 
        for u in UserTable do 
        set user 
        where (u.UserID = user.UserID)
    }
    Database.Query conn.UpdateAsync 
