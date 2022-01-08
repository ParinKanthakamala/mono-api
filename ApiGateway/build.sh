#dotnet build "ApiGateway.csproj" -c Release -o /app/build
#docker build -t connection .
docker build -t api_gateway .
#docker run -it --rm -p 80:5000 --name aspnetcore_sample api_gateway
docker-compose up -d