# ---------- BUILD STAGE ----------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY Karima_Collection/Karima_Collection.csproj Karim_aCollection/
RUN dotnet restore Karima_Collection/Karima_Collection.csproj

COPY . .
WORKDIR /src/Karima_Collection
RUN dotnet publish -c Release -o /app/publish

# ---------- RUNTIME STAGE ----------
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "KarimaCollection.dll"]
