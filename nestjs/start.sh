# rm package-lock.json
# rm yarn.lock
# yarn install

SERVICE_NAME="${PWD##*/}"
PORT=80
docker-compose down
docker container stop $SERVICE_NAME
docker container rm $SERVICE_NAME
docker rmi $SERVICE_NAME
kill-port --port $PORT
docker build -t $SERVICE_NAME .
docker-compose up -d
