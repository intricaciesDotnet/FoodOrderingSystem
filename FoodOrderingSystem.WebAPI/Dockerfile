#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FoodOrderingSystem.WebAPI/FoodOrderingSystem.WebAPI.csproj", "FoodOrderingSystem.WebAPI/"]
COPY ["FoodOrderingSystem.Application/FoodOrderingSystem.Application.csproj", "FoodOrderingSystem.Application/"]
COPY ["FoodOrderingSystem.Core/FoodOrderingSystem.Core.csproj", "FoodOrderingSystem.Core/"]
COPY ["FoodOrderingSystem.Infrastructure/FoodOrderingSystem.Infrastructure.csproj", "FoodOrderingSystem.Infrastructure/"]
COPY ["FoodOrderingSystem.Persistence/FoodOrderingSystem.Persistence.csproj", "FoodOrderingSystem.Persistence/"]
RUN dotnet restore "./FoodOrderingSystem.WebAPI/FoodOrderingSystem.WebAPI.csproj"
COPY . .
WORKDIR "/src/FoodOrderingSystem.WebAPI"
RUN dotnet build "./FoodOrderingSystem.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FoodOrderingSystem.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodOrderingSystem.WebAPI.dll"]