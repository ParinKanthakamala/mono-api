#FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
#WORKDIR /app
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["Hello/Hello.csproj", "Hello/"]
#RUN dotnet restore "Hello/Hello.csproj"
#COPY . .
#WORKDIR "/src/Hello"
#RUN dotnet build "Hello.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Hello.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Hello.dll"]



FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base

RUN apt-get update && apt-get install -y gcc-multilib && apt-get install -y libcurl3-gnutls
WORKDIR /app
EXPOSE 2275
EXPOSE 44303

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY . .
WORKDIR /src/SampleWebApp
RUN dotnet nuget add source /src/packages
RUN dotnet restore
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

EXPOSE 80
ENTRYPOINT ["dotnet", "SampleWebApp.dll"]