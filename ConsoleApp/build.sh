APP="${PWD##*/}"
rm -r ./app/
dotnet build ConsoleApp.csproj -c Release -o ./app/
#docker-compose up -d
#dotnet ./app/$APP.dll
