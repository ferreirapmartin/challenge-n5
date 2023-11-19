# Challenge N5

Para este challenge, se implementó la siguiente arquitectura:

![Architecture Diagram](docs/architecture_diagram.png?raw=true "Architecture Diagram")

El frontend (SPA) se desarrolló utilizando React 18 con TypeScript. Para gestionar el estado de la aplicación se utilizó Redux junto con Redux-Saga para el manejo de los side effects. Como Web System, Material-UI, específicamente el package MUI. Para las validaciones de formularios se optó por Formik y YUP. Además, la aplicación es multi-idioma (escritura occidental) a través de i18next.

La API REST se implementó con .NET Core 8 siguiendo una arquitectura DDD con CQRS (utilizando el patrón de diseño Mediator con el package MediatR). Para el manejo de inyección de dependencia se utilizó Microsoft.Extensions.DependencyInjection (nativo). Como ORM Entity Framework Core. Para la comunicación con Apache Kafka, Confluent.Kafka. Y, para ElasticSearch, el package "NEST".

El "backend" consta de 4 capas:

![Architecture Diagram](docs/layers.png?raw=true "Architecture Diagram")

## Getting Started

### Prerequisites

Se debe tener instalado [Docker](https://docs.docker.com/get-docker/)

### Installation

Parado en el root del proyecto (mismo nivel que archivo `compose.yml`) ejecutar:

```sh
docker compose build
```

Una vez hecho esto, se debe ejecutar:

```sh
docker compose up -d
```

## Usage

### Web

Abrir un navegador e ingresar a: http://localhost:3500

### API REST (Swagger)

Abrir un navegador e ingresar a: http://localhost:5075/swagger

> Nota: También se puede utilizar el archivo _ms-permission\src\ChallengeN5.Distributed.REST\ChallengeN5.Distributed.REST.http_

### DB:

Utilizando algún IDE para base de datos y conectarse con:

- Server: localhost
- Port: 1433
- Database: master
- User: sa
- Password: ChallengeN5

### Apache Kafka

Ejecutar en una terminal:

```sh
docker exec -it challengen5-kafka-1 bash
```

> Nota: "challengen5-kafka-1" es el nombre del container, puede llegar a variar. Se puede ver dentro de Docker Desktop

Luego, ejecutar:

```sh
kafka-console-consumer.sh --bootstrap-server kafka:9092 --topic ChallengeN5 --from-beginning
```

### ElasticSearch

Abrir un navegador e ingresar a: http://localhost:9200/\_search?filter_path=hits.hits.\_source

> Nota: También se puede utilizar el archivo _ms-permission\src\ChallengeN5.Distributed.REST\ChallengeN5.Distributed.REST.http_

## Pendings

Por cuestión de tiempo, no pude terminar lo siguiente:

- Units e Integrations tests