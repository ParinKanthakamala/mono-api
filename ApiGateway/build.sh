APP="${PWD##*/}"
rm -r ./app/
dotnet build ApiGateway.csproj -c Release -o ./app/
cd ./app/
pm2 start "dotnet $APP.dll" --name $APP
cd ..