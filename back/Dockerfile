# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src
COPY back.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Utilisateur non-root (bonnes pratiques)
RUN addgroup --system appgroup && adduser --system appuser --ingroup appgroup

COPY --from=build /app/publish ./
USER appuser

EXPOSE 80
ENTRYPOINT ["dotnet", "back.dll"]
