<!-- type: findings | status: active | since: 2026-08-16 | applies-to: MinimalAPIDemoApp -->

# Findings: MinimalAPIDemoApp

## repo_distiller bugs

- **2026-08-16 -- `deterministic.entrypoints[0]` mis-typed as `"cli"`.** The distillate
  lists `{"type": "cli", "path": "DataAccess/DataAccess.csproj"}` as an entrypoint.
  `DataAccess.csproj` (`Microsoft.NET.Sdk`, no `<OutputType>` override) builds a class
  library, not an executable/CLI -- it has no `Main`/console entrypoint and is only ever
  consumed as a `ProjectReference` from `MinimalAPIDemo.csproj`. It is not a repo
  entrypoint at all under this contract's meaning (console script / HTTP route root /
  worker main). Per Stage 2 rule, this deterministic field was left as-parsed (not
  hand-edited) and README/architecture.md were written to describe entrypoints
  correctly (HTTP routes only) rather than propagating the bug. Flagging so
  `repo_distiller`'s entrypoint classifier can be fixed to exclude non-executable
  `ProjectReference` targets from `type: cli`.
