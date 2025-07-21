# syntax=docker/dockerfile:1

################################################################################
# 🧑‍🏭 Étape 1 – Build (multi-stage) pour réduire la taille finale
################################################################################
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src
COPY *.sln ./
COPY Epiceries.Core/*.csproj Epiceries.Core/
COPY Epiceries.Desktop/*.csproj Epiceries.Desktop/
COPY Epiceries.Android/*.csproj Epiceries.Android/
RUN dotnet restore

COPY . .
WORKDIR /src/Epiceries.Desktop
RUN dotnet publish -c Release -o /app/publish \
    /p:UseAppHost=false

################################################################################
# 🧰 Étape 2 – Image finale légère
################################################################################
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Utilisation d’un utilisateur non root (sécurité)
RUN addgroup --system appgroup && \
    adduser --system appuser --ingroup appgroup

COPY --from=build /app/publish ./
USER appuser

# Exposer le port par défaut
EXPOSE 80

ENTRYPOINT ["dotnet", "Epiceries.Desktop.dll"]
