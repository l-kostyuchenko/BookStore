#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/BookStore.WebApi/BookStore.WebApi.csproj", "Presentation/BookStore.WebApi/"]
COPY ["Core/BookStore.Application/BookStore.Application.csproj", "Core/BookStore.Application/"]
COPY ["Core/BookStore.Domain/BookStore.Domain.csproj", "Core/BookStore.Domain/"]
COPY ["Infrastructure/BookStore.Persistence/BookStore.Persistence.csproj", "Infrastructure/BookStore.Persistence/"]
RUN dotnet restore "./Presentation/BookStore.WebApi/./BookStore.WebApi.csproj"
COPY . .
WORKDIR "/src/Presentation/BookStore.WebApi"
RUN dotnet build "./BookStore.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookStore.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookStore.WebApi.dll"]