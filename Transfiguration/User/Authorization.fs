module Authorization
open System
open Dapper.FSharp
open Dapper.FSharp.MSSQL
open Database
open System.Data.SqlClient


let AuthorizationTable = table<Authorization> 

let GetClaimsByUserID userid = 
    select { 
       for a in AuthorizationTable do 
        where(a.UserID = userid)
    } |> SelectQuery<Authorization>

let GetClaimsByType claimtype = 
    select { 
       for a in AuthorizationTable do 
        where(a.ClaimType = claimtype)
    } |> SelectQuery<Authorization>

let AddClaim claim = 
    insert {
        into AuthorizationTable
        value(claim)
    } |> InsertQuery 

let DeleteClaim claim = 
    delete { 
        for a in AuthorizationTable do 
           where(a.Claim = claim.Claim && a.ClaimType = claim.ClaimType && a.UserID = claim.UserID)
    }