#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ILearnerAPI/ILearnerAPI.csproj", "ILearnerAPI/"]
COPY ["ILearnerAPI.Application/ILearnerAPI.Application.csproj", "ILearnerAPI.Application/"]
COPY ["ILeanerAPI.Domain/ILeanerAPI.Domain.csproj", "ILeanerAPI.Domain/"]
COPY ["ILearnerAPI.Infrastructure/ILearnerAPI.Infrastructure.csproj", "ILearnerAPI.Infrastructure/"]
RUN dotnet restore "./ILearnerAPI/ILearnerAPI.csproj"
COPY . .
WORKDIR "/src/ILearnerAPI"
RUN dotnet build "./ILearnerAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ILearnerAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ILearnerAPI.dll"]