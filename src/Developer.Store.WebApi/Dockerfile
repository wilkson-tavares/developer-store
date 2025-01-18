#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Developer.Store.WebApi/Developer.Store.WebApi.csproj", "src/Developer.Store.WebApi/"]
COPY ["src/Developer.Store.IoC/Developer.Store.IoC.csproj", "src/Developer.Store.IoC/"]
COPY ["src/Developer.Store.Domain/Developer.Store.Domain.csproj", "src/Developer.Store.Domain/"]
COPY ["src/Developer.Store.Common/Developer.Store.Common.csproj", "src/Developer.Store.Common/"]
COPY ["src/Developer.Store.Application/Developer.Store.Application.csproj", "src/Developer.Store.Application/"]
COPY ["src/Developer.Store.ORM/Developer.Store.ORM.csproj", "src/Developer.Store.ORM/"]
RUN dotnet restore "./src/Developer.Store.WebApi/Developer.Store.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Developer.Store.WebApi"
RUN dotnet build "./Developer.Store.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Developer.Store.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Developer.Store.WebApi.dll"]