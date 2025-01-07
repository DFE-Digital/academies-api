# Set the major version of dotnet
ARG DOTNET_VERSION=8.0

# ==============================================
# .NET: SDK Builder
# ==============================================
FROM "mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION}-azurelinux3.0" AS builder
WORKDIR /build
RUN ["tdnf", "update", "--security", "-y"]
RUN ["tdnf", "clean", "all"]
ARG CI
ENV CI=${CI}
COPY ./script/web-docker-entrypoint.sh /app/docker-entrypoint.sh

## START: Restore Packages
ARG PROJECT_NAME="TramsDataApi"
COPY ./${PROJECT_NAME}.sln  ./
COPY ./${PROJECT_NAME}/${PROJECT_NAME}.csproj           ./${PROJECT_NAME}/

ARG PROJECT_NAME="Dfe.Academies"
COPY ./${PROJECT_NAME}.Api.Infrastructure/${PROJECT_NAME}.Infrastructure.csproj ./${PROJECT_NAME}.Api.Infrastructure/
COPY ./${PROJECT_NAME}.Application/${PROJECT_NAME}.Application.csproj           ./${PROJECT_NAME}.Application/
COPY ./${PROJECT_NAME}.Domain/${PROJECT_NAME}.Domain.csproj                     ./${PROJECT_NAME}.Domain/
COPY ./${PROJECT_NAME}.Utils/${PROJECT_NAME}.Utils.csproj                       ./${PROJECT_NAME}.Utils/

# Mount GitHub Token as a Docker secret so that NuGet Feed can be accessed
RUN --mount=type=secret,id=github_token dotnet nuget add source --username USERNAME --password $(cat /run/secrets/github_token) --store-password-in-clear-text --name github "https://nuget.pkg.github.com/DFE-Digital/index.json"
RUN ["dotnet", "restore", "TramsDataApi"]
## END: Restore Packages

ARG PROJECT_NAME="TramsDataApi"
COPY ./${PROJECT_NAME}/ ./${PROJECT_NAME}/

ARG PROJECT_NAME="Dfe.Academies"
COPY ./${PROJECT_NAME}.Api.Infrastructure/ ./${PROJECT_NAME}.Api.Infrastructure/
COPY ./${PROJECT_NAME}.Application/        ./${PROJECT_NAME}.Application/
COPY ./${PROJECT_NAME}.Domain/             ./${PROJECT_NAME}.Domain/
COPY ./${PROJECT_NAME}.Utils/              ./${PROJECT_NAME}.Utils/

RUN ["dotnet", "publish", "TramsDataApi", "-c", "Release", "-o", "/app", "/p:CI=${CI}", "--no-restore"]

# ==============================================
# Entity Framework: Migration Builder
# ==============================================
FROM builder AS efbuilder
WORKDIR /build
ENV PATH=$PATH:/root/.dotnet/tools
RUN ["mkdir", "/sql"]
RUN ["dotnet", "tool", "install", "--global", "dotnet-ef"]
RUN ["dotnet", "ef", "migrations", "bundle", "-r", "linux-x64", "--configuration", "Release", "-p", "TramsDataApi", "--context", "TramsDataApi.DatabaseModels.LegacyTramsDbContext", "--no-build", "-o", "/sql/migratelegacydb"]
RUN ["dotnet", "ef", "migrations", "bundle", "-r", "linux-x64", "--configuration", "Release", "-p", "TramsDataApi", "--context", "TramsDataApi.DatabaseModels.TramsDbContext", "--no-build", "-o", "/sql/migratedb"]
COPY ./script/init-docker-entrypoint.sh /sql/entrypoint.sh
RUN ["chmod", "+x", "/sql/entrypoint.sh"]

# ==============================================
# Entity Framework: Migration Runner
# ==============================================
FROM "mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION}-azurelinux3.0" AS initcontainer
WORKDIR /sql
COPY --from=efbuilder /sql /sql
COPY --from=builder /app/appsettings* /TramsDataApi/
RUN chown "$APP_UID" "/sql" -R
RUN chown "$APP_UID" "/TramsDataApi" -R
USER $APP_UID

# ==============================================
# .NET: Runtime
# ==============================================
FROM "mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION}-azurelinux3.0" AS final
WORKDIR /app
LABEL org.opencontainers.image.source="https://github.com/DFE-Digital/academies-api"
LABEL org.opencontainers.image.description="Academies API"

COPY --from=builder /app /app
RUN ["chmod", "+x", "./docker-entrypoint.sh"]
USER $APP_UID
