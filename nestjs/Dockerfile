FROM node:14 AS builder
WORKDIR /app
COPY ./package.json ./
RUN npm install
COPY . .
RUN npm run build


FROM node:14-alpine
WORKDIR /app
COPY --from=builder /app ./
CMD ["npm", "run", "start:prod"]


#FROM node:15.13.0-alpine
#ENV APP_ROOT /usr/src/app
#WORKDIR ${APP_ROOT}
#COPY . ${APP_ROOT}
#RUN yarn install
#ENV HOST 0.0.0.0
