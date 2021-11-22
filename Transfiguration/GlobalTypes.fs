[<AutoOpen>]
module GlobalTypes
open System

//This file contains all of the types for the domain. 
type Authentication = {
    AuthenticationType: string 
    AuthEmail: string
    UserID: Guid
}
type Authorization = { 
    UserID: Guid
    ClaimType: string 
    Claim: string 
} 

type User = { 
    UserID: Guid
    FirstName: string 
    LastName: string
    Email: string
}
type Specialty = { 
    SpecialtyID: Guid
    SpecialtyName: string
}

type ApplicationCycle = { 
    ApplicationCycleID: Guid 
    SpecialtyID: Guid
    StartDate: DateTime
    EndDate: DateTime 
    ApplicationLimit: int
} 

type CycleParticipant = {
    ProgramID: Guid
    ApplicationCycleID: Guid

}
type Application = {
    ApplicantID: Guid
    CycleParticipantID: Guid

} 
type Contact = { 
    ContactID: Guid
    Address: string option
    PhoneNumber: string option
    Email: string option
}
type Program = { 
    ProgramID: Guid
    ProgramName: string 
    Specialty: Guid
}
type Applicant = { 
    UserID: Guid
    FirstName: string
    LastName: string
}

type ActionResult<'a> = DatabaseError of string * string | ValidationError of (string * string) list | OperationSuccess of 'a | EmptyResult

