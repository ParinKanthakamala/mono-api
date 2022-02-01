FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Libraries/DesignPattern/DesignPattern.csproj", "DesignPattern/"]
RUN dotnet restore "Libraries/DesignPattern/DesignPattern.csproj"
COPY . .
WORKDIR "/src/DesignPattern"
RUN dotnet build "DesignPattern.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesignPattern.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesignPattern.dll"]
