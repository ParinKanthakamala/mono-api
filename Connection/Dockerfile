FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Connection/Connection.csproj", "Connection/"]
RUN dotnet restore "Connection/Connection.csproj"
COPY . .
WORKDIR "/src/Connection"
RUN dotnet build "Connection.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Connection.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Connection.dll"]
