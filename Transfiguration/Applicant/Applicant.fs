module Applicant
open System
open Database
open Dapper.FSharp
open Dapper.FSharp.MSSQL

let private ApplicantTable = table<Applicant>

let CreateApplicant applicant = 
    insert {
    into ApplicantTable
    value applicant } |> Database.InsertQuery


let UpdateApplicant Applicant = 
    update {
    for a in ApplicantTable do 
        set Applicant
        where(a.UserID = Applicant.UserID) } |> UpdateQuery


let DeleteApplicant UserID = delete { 
    for a in ApplicantTable do 
        where(a.UserID = UserID) } |> DeleteQuery

let GetApplicant UserID = 
    select { 
    for a in ApplicantTable do
    where(a.UserID = a.UserID)
    } |> SelectQuery

