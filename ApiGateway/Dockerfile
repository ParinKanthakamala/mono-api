FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt-get update

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /app
#COPY ./app .
#RUN dotnet restore "./ApiGateway.csproj"
#COPY . .
#WORKDIR /src/.
#RUN dotnet build "ApiGateway.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "ApiGateway.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiGateway.dll"]
