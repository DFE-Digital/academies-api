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

FROM builder AS efbuilder
WORKDIR /build
ENV PATH=$PATH:/root/.dotnet/tools

# Create /sql  
RUN mkdir -p /sql

# Copy and set permissions for init script
COPY ./script/init-docker-entrypoint.sh /sql/entrypoint.sh
RUN chmod +x /sql/entrypoint.sh

# ==============================================
# Entity Framework: Migration Runner
# ==============================================
FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION}-azurelinux3.0 AS initcontainer
WORKDIR /sql

# Copy appsettings
COPY --from=efbuilder /sql /sql
COPY --from=builder /app/appsettings* /TramsDataApi/

# Set ownership and switch user
RUN chown "$APP_UID" /sql -R && \
    chown "$APP_UID" /TramsDataApi -R
USER $APP_UID

# ==============================================
# .NET: Runtime
# ==============================================
FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION}-azurelinux3.0 AS final
WORKDIR /app
LABEL org.opencontainers.image.source="https://github.com/DFE-Digital/academies-api"
LABEL org.opencontainers.image.description="Academies API"

# Copy published app and set permissions
COPY --from=builder /app /app
RUN chmod +x ./docker-entrypoint.sh
USER $APP_UID