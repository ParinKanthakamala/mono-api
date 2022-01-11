#dotnet build "ApiGateway.csproj" -c Release -o /app/build
#docker build -t connection .
docker build -t api_gateway .
#docker run -it --rm -p 80:5000 --name aspnetcore_sample api_gateway
docker-compose up -d



#docker run -d --hostname my-rabbit --name some-rabbit -p 5672:5672 -p 8080:15672 rabbitmq:3-management
