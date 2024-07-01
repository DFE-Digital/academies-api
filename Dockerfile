FROM mcr.microsoft.com/dotnet/sdk:8.0-bookworm-slim AS build
WORKDIR /build

ENV DEBIAN_FRONTEND=noninteractive

COPY . .

RUN mkdir -p /app/SQL
RUN touch /app/SQL/DbMigrationScriptLegacy.sql
RUN touch /app/SQL/DbMigrationScript.sql

RUN --mount=type=secret,id=github_token dotnet nuget add source --username USERNAME --password $(cat /run/secrets/github_token) --store-password-in-clear-text --name github "https://nuget.pkg.github.com/DFE-Digital/index.json"
RUN dotnet restore TramsDataApi.sln
RUN dotnet new tool-manifest
RUN dotnet tool install dotnet-ef --version 6.0.5
ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet ef migrations script --output /app/SQL/DbMigrationScriptLegacy.sql --project TramsDataApi --context TramsDataApi.DatabaseModels.LegacyTramsDbContext --idempotent -v
RUN dotnet ef migrations script --output /app/SQL/DbMigrationScript.sql --project TramsDataApi --context TramsDataApi.DatabaseModels.TramsDbContext --idempotent --no-build -v

# this build has no effect on ef migrations because it is a "Release" configuration
RUN dotnet build -c Release TramsDataApi.sln --no-restore
RUN dotnet publish TramsDataApi -c Release -o /app --no-restore

ARG ASPNET_IMAGE_TAG
FROM mcr.microsoft.com/dotnet/aspnet:6.0.31-bullseye-slim AS final

RUN apt-get update
RUN apt-get install unixodbc curl gnupg -y
RUN curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -
RUN curl https://packages.microsoft.com/config/debian/11/prod.list | tee /etc/apt/sources.list.d/msprod.list
RUN apt-get update
RUN ACCEPT_EULA=Y apt-get install msodbcsql18 mssql-tools18 -y

COPY --from=build /app /app

WORKDIR /app
COPY ./script/web-docker-entrypoint.sh ./docker-entrypoint.sh
RUN chmod +x ./docker-entrypoint.sh
EXPOSE 80/tcp
