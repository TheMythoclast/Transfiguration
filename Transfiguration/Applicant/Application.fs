module Application
open System
open Dapper.FSharp
open Dapper.FSharp.MSSQL

let private ApplicationTable = table<Application> 

let GetApplicationsForApplicant ApplicantID = select { 
    for application in ApplicationTable do 
        where(application.ApplicantID = ApplicantID) } |> SelectQuery

let GetApplicationsForParticipant ParticipantID = select { 
    for application in ApplicationTable do 
        where(application.CycleParticipantID = ParticipantID) } |> SelectQuery

let DeleteApplication ApplicationID = delete { 
    for application in ApplicationTable do 
        where(application.ApplicationID = ApplicationID) } |> DeleteQuery

let CreateApplication ApplicantID ParticipantID = 
    let newapp = { ApplicationID = Guid.NewGuid(); ApplicantID = ApplicantID; CycleParticipantID = ParticipantID}
    insert { 
        into ApplicationTable 
        value newapp } |> InsertQuery