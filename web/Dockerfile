FROM node:alpine as build-step
RUN mkdir -p /app
RUN npm cache clear --force
WORKDIR /app
COPY package.json /app
RUN npm install

ENV NODE_ENV=production
COPY . /app
RUN npm run build 

FROM nginx
COPY --from=build-step /app/build /usr/share/nginx/html

EXPOSE 80

STOPSIGNAL SIGTERM

CMD ["nginx", "-g", "daemon off;"]