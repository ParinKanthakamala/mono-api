APP="${PWD##*/}"
dotnet build $APP.csproj -c Release -o ./app/
#docker build -t api-gateway .
#docker run -d --name api-container api-gateway

#cd ./app/
#pm2 start "dotnet $APP.dll" --name $APP
#cd ..
#docker run -it -p 8080:5000 -v $(pwd):/app -w "/app" [my-custom-image-name]
#docker run -it -p 80:5001 -v $(pwd):/app -w "/app" [api-gateway]

#docker stop api-gateway
#docker system prune -f
