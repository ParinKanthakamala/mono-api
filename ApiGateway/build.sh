rm -r ./app/
dotnet build ApiGateway.csproj -c Release -o ./app/
cd app
dotnet ApiGateway.dll
cd ..
