module User
open Authentication
open Database
open Dapper.FSharp
open Dapper.FSharp.MSSQL





let UserTable = table<User>

let insertUser user = 
    let insertQuery = insert { 
        into UserTable
        value user
    }
    insertQuery |> Database.InsertQuery

let GetUser userid = 
    let selectQuery = select { 
        for u in UserTable do 
            where(u.UserID = userid)
    }
    selectQuery |> Database.SelectQuery
    
let UpdateUser user = 
    let updateQuery = update { 
        for u in UserTable do 
        set user 
        where (u.UserID = user.UserID)
    }
    updateQuery |> Database.UpdateQuery
    
let DeleteUser user = 
    let deleteQuery = delete { 
        for u in UserTable do 
            where(u.UserID = user.UserID)
    }
    deleteQuery |> Database.DeleteQuery
