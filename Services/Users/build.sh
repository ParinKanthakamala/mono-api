APP="${PWD##*/}"
rm -r ./app/
dotnet build Prototype.csproj -c Release -o ./app/
#docker-compose up -d
#dotnet ./app/$APP.dll
cd app
dotnet Prototype.dll
cd ..
