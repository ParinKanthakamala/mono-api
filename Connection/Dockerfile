FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY Connection.csproj ./
RUN dotnet restore "./Connection.csproj"
COPY . .
WORKDIR /src/.
RUN dotnet build "Connection.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Connection.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Connection.dll"]