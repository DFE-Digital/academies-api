# trams-data-api
Simple api for getting data from the TRAMS system



## Development Setup
### Setting up local trams database image
We use Github Container Registry to host our docker images.
You can sign into ghcr.io by following the guide [here](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-container-registry#authenticating-to-the-container-registry).

Once signed into ghcr.io you can pull down and run the `trams-development-database` image using:

`docker run -d -p 1433:1433 ghcr.io/dfe-digital/trams-development-database:latest`

You can connect to the MSSQL Server on port `1433`.

### EntityFramework and Migrations

We currently have two database contexts defined: `LegacyTramsDbContext` and `TramsDbContext`

`LegacyTramsDbContext` is used to manage our models for tables which exist in the `sip` database and we have no control over - we treat these tables as read-only and don't commit migrations for them. If you do generate migrations for this context, it should not be commited to the repository.

`TramsDbContext` is the db context for models that we _do_ control, and we can generate migrations for. These migrations will be applied to the database in `dev`, `pre-prod`, and `prod`, and so should be commited to the repository when changes are made to models.

#### Generating Migrations

To generate migrations for `TramsDbContext`, use the following command:

```
dotnet ef migrations add <MIGRATION_NAME> --project TramsDataApi --context TramsDataApi.DatabaseModels.TramsDbContext -o Migrations/TramsDb
```

And to generate migrations for `LegacyTramsDbContext` use:

```
dotnet ef migrations add <MIGRATION_NAME> --project TramsDataApi --context TramsDataApi.DatabaseModels.LegacyTramsDbContext -o Migrations/LegacyTramsDb
```

Migrations put into the `Migrations/LegacyTramsDb` directory will not be commited to git.