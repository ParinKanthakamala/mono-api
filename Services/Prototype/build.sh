APP="${PWD##*/}"
rm -r ./app/
dotnet build Connection.csproj -c Release -o ./app/
#docker-compose up -d
#dotnet ./app/$APP.dll
cd app
dotnet Connection.dll
cd ..