module ResProgram
open System
open Dapper.FSharp
open Dapper.FSharp.MSSQL

let ProgramTable = table<Program>

let GetPrograms p = select { 
    for p in ProgramTable do 
        selectAll } |> SelectQuery

let GetProgramsBySpecialty SpecialtyID = select { 
    for p in ProgramTable do    
    where(p.Specialty = SpecialtyID) } |> SelectQuery