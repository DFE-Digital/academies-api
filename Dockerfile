# Stage 1
ARG ASPNET_IMAGE_TAG=3.1-bullseye-slim
ARG COMMIT_SHA=not-set

FROM mcr.microsoft.com/dotnet/sdk:3.1-bullseye AS build
WORKDIR /build

ENV DEBIAN_FRONTEND=noninteractive

COPY . .

RUN dotnet build TramsDataApi -c Release
RUN dotnet new tool-manifest
RUN dotnet tool install dotnet-ef --version 6.0.5
ENV PATH="$PATH:/root/.dotnet/tools"

RUN mkdir -p /app/SQL
RUN dotnet ef migrations script --output /app/SQL/DbMigrationScriptLegacy.sql --project TramsDataApi --context TramsDataApi.DatabaseModels.LegacyTramsDbContext --idempotent -v
RUN dotnet ef migrations script --output /app/SQL/DbMigrationScript.sql --project TramsDataApi --context TramsDataApi.DatabaseModels.TramsDbContext --idempotent -v
RUN touch /app/SQL/DbMigrationScript.sql
RUN touch /app/SQL/DbMigrationScriptLegacy.sql

RUN dotnet publish TramsDataApi -c Release -o /app --no-build
COPY ./script/web-docker-entrypoint.sh /app/docker-entrypoint.sh

# Stage 3 - Final
ARG ASPNET_IMAGE_TAG
FROM "mcr.microsoft.com/dotnet/aspnet:${ASPNET_IMAGE_TAG}" AS final

ARG COMMIT_SHA
RUN echo "Setting env releasetag=${COMMIT_SHA}"
ENV TramsDataApi:ReleaseTag="${COMMIT_SHA}"

RUN apt-get update
RUN apt-get install unixodbc curl gnupg -y
RUN curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -
RUN curl https://packages.microsoft.com/config/debian/11/prod.list | tee /etc/apt/sources.list.d/msprod.list
RUN apt-get update
RUN ACCEPT_EULA=Y apt-get install msodbcsql18 mssql-tools18 -y

COPY --from=build /app /app
WORKDIR /app
RUN chmod +x ./docker-entrypoint.sh
EXPOSE 80/tcp
