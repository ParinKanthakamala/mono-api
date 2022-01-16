APP="${PWD##*/}"
rm -r ./app/
dotnet build $APP.csproj -c Release -o ./app/
dotnet ./app/$APP.dll
