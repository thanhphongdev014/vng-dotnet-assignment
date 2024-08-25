#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 443
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BackgroundService.Host/BackgroundService.Host.csproj", "BackgroundService.Host/"]
COPY ["BackgroundService.EntityFrameworkCore/BackgroundService.EntityFrameworkCore.csproj", "BackgroundService.EntityFrameworkCore/"]
RUN dotnet restore "./BackgroundService.Host/BackgroundService.Host.csproj"
COPY . .
WORKDIR "/src/BackgroundService.Host"
RUN dotnet build "./BackgroundService.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BackgroundService.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackgroundService.Host.dll"]

