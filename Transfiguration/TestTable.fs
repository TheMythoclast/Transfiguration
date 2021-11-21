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
        value row
    } |> Database.InsertQuery