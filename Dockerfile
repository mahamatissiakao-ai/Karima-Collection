# Use the official .NET 9 SDK image to build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj and restore
COPY *.sln .
COPY Karima-Collection/*.csproj ./Karima-Collection/
RUN dotnet restore

# Copy everything else and publish
COPY Karima-Collection/. ./Karima-Collection/
WORKDIR /app/Karima=Collection
RUN dotnet publish -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Karima-Collection.dll"]
