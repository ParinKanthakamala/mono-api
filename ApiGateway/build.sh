APP="${PWD##*/}"
rm -r ./app/
dotnet build ApiGateway.csproj -c Release -o ./app/
#docker-compose up -d
#dotnet ./app/$APP.dll
