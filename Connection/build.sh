rm -r ./app/
dotnet build Connection.csproj -c Release -o ./app/
docker-compose up -d
