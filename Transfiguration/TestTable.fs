module TestTable
open Dapper.FSharp
open Dapper.FSharp.MSSQL
open System

type TestRow = { 
    TestID : Guid
    SomeColumn : string
}

let testTable = table'<TestRow> "TestTable"

let createRow row = 
    insert { 
        into testTable
        value row } |> Database.InsertQuery 
    
let GetTestRowByID rowid = select { 
    for m in testTable do 
    where(m.TestID = rowid) } |> Database.SelectQuery<TestRow>

let testSelect rowID = select { 
    for m in testTable do   
        where(m.TestID = rowID) } |> Database.SelectQuery<TestRow>

let getTests = select { 
    for m in testTable do 
        selectAll } |> Database.SelectQuery<TestRow>
