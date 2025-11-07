# Set the major version of dotnet
ARG DOTNET_VERSION=8.0

# ==============================================
# .NET: SDK Builder
# ==============================================
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION}-azurelinux3.0 AS builder
WORKDIR /build

# Update and install dependencies
RUN tdnf update --security -y && \
    tdnf clean all

ARG CI
ENV CI=${CI}

# Copy entrypoint script
COPY ./script/web-docker-entrypoint.sh /app/docker-entrypoint.sh

# Restore Packages
COPY ./TramsDataApi.sln ./
COPY ./TramsDataApi/TramsDataApi.csproj ./TramsDataApi/
COPY ./Dfe.Academies.Api.Infrastructure/Dfe.Academies.Infrastructure.csproj ./Dfe.Academies.Api.Infrastructure/
COPY ./Dfe.Academies.Application/Dfe.Academies.Application.csproj ./Dfe.Academies.Application/
COPY ./Dfe.Academies.Domain/Dfe.Academies.Domain.csproj ./Dfe.Academies.Domain/
COPY ./Dfe.Academies.Utils/Dfe.Academies.Utils.csproj ./Dfe.Academies.Utils/

# Mount GitHub Token and restore
RUN --mount=type=secret,id=github_token dotnet nuget add source --username USERNAME --password $(cat /run/secrets/github_token) --store-password-in-clear-text --name github "https://nuget.pkg.github.com/DFE-Digital/index.json" && \
    dotnet restore TramsDataApi

# Copy remaining source and publish
COPY ./TramsDataApi/ ./TramsDataApi/
COPY ./Dfe.Academies.Api.Infrastructure/ ./Dfe.Academies.Api.Infrastructure/
COPY ./Dfe.Academies.Application/ ./Dfe.Academies.Application/
COPY ./Dfe.Academies.Domain/ ./Dfe.Academies.Domain/
COPY ./Dfe.Academies.Utils/ ./Dfe.Academies.Utils/

RUN dotnet publish TramsDataApi -c Release -o /app --no-restore


# ==============================================
# .NET: Runtime
# ==============================================
FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION}-azurelinux3.0 AS final
WORKDIR /app
LABEL org.opencontainers.image.source="https://github.com/DFE-Digital/academies-api"
LABEL org.opencontainers.image.description="Academies API"

# Copy published app and appsettings (from builder)
COPY --from=builder /app /app
COPY --from=builder /app/appsettings* /TramsDataApi/

RUN chmod +x ./docker-entrypoint.sh
USER $APP_UID