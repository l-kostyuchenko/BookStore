#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BookStore.Web/BookStore.Web.csproj", "BookStore.Web/"]
COPY ["BookStore.Application/BookStore.Application.csproj", "BookStore.Application/"]
COPY ["BookStore.Domain/BookStore.Domain.csproj", "BookStore.Domain/"]
COPY ["BookStore.Infrastructure/BookStore.Persistence.csproj", "BookStore.Infrastructure/"]
RUN dotnet restore "./BookStore.Web/./BookStore.Web.csproj"
COPY . .
WORKDIR "/src/BookStore.Web"
RUN dotnet build "./BookStore.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookStore.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookStore.Web.dll"]