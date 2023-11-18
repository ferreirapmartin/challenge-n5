#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ChallengeN5.Distributed.REST/ChallengeN5.Distributed.REST.csproj", "ChallengeN5.Distributed.REST/"]
RUN dotnet restore "./ChallengeN5.Distributed.REST/./ChallengeN5.Distributed.REST.csproj"
COPY . .
WORKDIR "/src/ChallengeN5.Distributed.REST"
RUN dotnet build "./ChallengeN5.Distributed.REST.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ChallengeN5.Distributed.REST.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "ChallengeN5.Distributed.REST.dll"]