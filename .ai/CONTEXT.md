<!-- type: context | status: active | since: 2026-08-16 | applies-to: MinimalAPIDemoApp -->

# Project context: MinimalAPIDemoApp

## Identity
- **Repo:** `github.com/LogicallyTyped/MinimalAPIDemoApp` (PUBLIC)
- **Local:** `C:\source\github.com\LogicallyTyped\MinimalAPIDemoApp\`
- **Employer:** none (personal project)
- **Standards overlay:** personal only — `C:\source\github.com\ProgramandoBonito\conventions\`

## Purpose
Small demo/learning solution for ASP.NET Core Minimal APIs. `MinimalAPIDemoApp.sln` has two
projects: `MinimalAPIDemo` (the API itself — `Microsoft.NET.Sdk.Web`, target `net9.0`,
`Microsoft.AspNetCore.OpenApi` + `Scalar.AspNetCore` for OpenAPI/API-reference docs) and
`DataAccess` (referenced by the API project, plus `UserData`/`ISqlDataAccess` types per commit
history — a small SQL-backed data-access layer; `TestDB`/`UserDB` folders alongside suggest
local SQL Server LocalDB usage rather than a portable/embedded database). No README exists.
Two commits total (`git log`): initial project structure + data access layer, then a
`UserData`/`ISqlDataAccess` follow-up. This is a demo/reference repo, not a maintained
product — there is no indication of further active development.

## Deviations

None declared.
