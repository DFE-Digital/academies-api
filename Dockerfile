# Set the major version of dotnet
ARG DOTNET_VERSION=8.0

# Build the app using the dotnet SDK
FROM "mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION}-azurelinux3.0" AS build
WORKDIR /build
ARG CI
ENV CI=${CI}

COPY . .
COPY ./script/web-docker-entrypoint.sh /app/docker-entrypoint.sh

# Mount GitHub Token as a Docker secret so that NuGet Feed can be accessed
RUN --mount=type=secret,id=github_token dotnet nuget add source --username USERNAME --password $(cat /run/secrets/github_token) --store-password-in-clear-text --name github "https://nuget.pkg.github.com/DFE-Digital/index.json"

# Generate the Entity Framework migration scripts
RUN ["dotnet", "new", "tool-manifest"]
RUN ["dotnet", "tool", "install", "dotnet-ef", "--version", "8.0.11"]
RUN ["mkdir", "-p", "/app/SQL"]
RUN ["touch", "/app/SQL/DbMigrationScriptOutput.txt"]
RUN ["touch", "/app/SQL/DbMigrationScriptOutputLegacy.txt"]
RUN ["dotnet", "restore", "TramsDataApi.sln"]
RUN ["dotnet", "ef", "migrations", "script", "--output", "/app/SQL/DbMigrationScriptLegacy.sql", "--project", "TramsDataApi", "--context", "TramsDataApi.DatabaseModels.LegacyTramsDbContext", "--idempotent"]
RUN ["dotnet", "ef", "migrations", "script", "--output", "/app/SQL/DbMigrationScript.sql", "--project", "TramsDataApi", "--context", "TramsDataApi.DatabaseModels.TramsDbContext", "--idempotent"]

# Build and publish the dotnet solution
RUN dotnet build TramsDataApi.sln --no-restore -c Release -p CI=${CI}
RUN ["dotnet", "publish", "TramsDataApi", "--no-build", "-o", "/app"]

# Install SQL tools to allow migrations to be run
FROM "mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION}-azurelinux3.0" AS base
RUN curl "https://packages.microsoft.com/config/rhel/9/prod.repo" | tee /etc/yum.repos.d/mssql-release.repo
ENV ACCEPT_EULA=Y
RUN ["tdnf", "update"]
RUN ["tdnf", "install", "-y", "mssql-tools18"]
RUN ["tdnf", "clean", "all"]

# Build a runtime environment
FROM base AS final
WORKDIR /app
LABEL org.opencontainers.image.source="https://github.com/DFE-Digital/academies-api"
LABEL org.opencontainers.image.description="Academies API"

COPY --from=build /app /app
RUN ["chmod", "+x", "./docker-entrypoint.sh"]
RUN chown "$APP_UID" "/app/SQL" -R
USER $APP_UID
