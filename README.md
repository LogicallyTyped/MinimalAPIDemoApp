# MinimalAPIDemoApp

## What this is

A small ASP.NET Core Minimal API demo for managing user records (create, read, update,
delete) backed by a SQL Server database accessed through stored procedures. It is a
two-project solution: `MinimalAPIDemo` (the HTTP API — routes and request handling) and
`DataAccess` (a class library that talks to SQL Server via Dapper). Consumers are HTTP/web
clients that call the `/Users` endpoints; there is no other repo or agent that depends on
this one. This is a demo/reference project, not a maintained product.

## Quickstart

Prerequisites: .NET 9 SDK, and a reachable SQL Server instance.

1. Deploy the SQL project schema (`TestDB/` or `UserDB/` — table `dbo.User` and the
   `spuGetAll` / `spuGet` / `spuInsert` / `spuUpdate` / `spuDelete` stored procedures) to
   your SQL Server instance.
2. Point the `ConnectionStrings:Default` setting (see Configuration below) at that
   instance — via `appsettings.Development.json`, user-secrets, or an environment
   variable override. Do not commit real connection strings.
3. Run the API:

```
dotnet run --project MinimalAPIDemo
```

No automated tests exist in this repo.

## Entrypoints

- `MinimalAPIDemo/Program.cs` — the HTTP entrypoint; wires up dependency injection
  (`ISqlDataAccess`, `IUserData`) and starts the Kestrel web server.
- HTTP routes (defined in `MinimalAPIDemo/Api.cs`): `GET /Users`, `GET /Users/{id}`,
  `POST /Users`, `PUT /Users`, `DELETE /Users/{id}`.
- `DataAccess/DataAccess.csproj` is a class library referenced by `MinimalAPIDemo` — it
  is not a separate runnable entrypoint (the repo's doc-distillation tooling wrongly
  lists it as one; a known distiller bug).

## Configuration

Required configuration names (values are supplied via `appsettings.*.json`,
user-secrets, or environment variables — never hardcode secrets in source):

- `AllowedHosts`
- `ConnectionStrings:Default` (sensitive — the SQL Server connection string)
- `Logging:LogLevel:Default`
- `Logging:LogLevel:Microsoft.AspNetCore`

## Dependencies

Runtime (via NuGet):
- `Dapper` — micro-ORM used to call stored procedures.
- `Microsoft.Data.SqlClient` / `System.Data.SqlClient` — SQL Server connectivity.
- `Microsoft.Extensions.Configuration.Abstractions` — reads `ConnectionStrings:Default`.
- `Microsoft.AspNetCore.OpenApi` — generates the OpenAPI document.
- `Scalar.AspNetCore` — API reference UI served in Development.

Build-time: .NET 9 SDK (`net9.0` target framework, both projects).

## Operational surface

No scheduled tasks or background services. The operational surface is the HTTP API
itself — five routes under `/Users` — plus the SQL Server database it depends on for
storage. There is no hosted/deployed instance associated with this repo; it runs
wherever `dotnet run` (or a published build) is executed against a configured database.

## Deeper docs

- `.ai/architecture.md` — component diagram, data flow, and operational gotchas.
- `.ai/CONTEXT.md` — standards precedence declaration for this repo.
- `.ai/distillate.json` — machine-readable summary this documentation was rendered from.
---
schema_version: 1.0.0
distilled_from_sha: 1551ac32a1a7c0f675f6d14bf3f94d4ba046a692
verified_sha: 1551ac32a1a7c0f675f6d14bf3f94d4ba046a692
verified_at: 2026-08-16T18:34:13Z
