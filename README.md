# Challenge N5

Challenge N5, en cual el front fue implementado con React 18, utilizando MUI, Redux, Redux Sagas, Axios, Formik y YUP.

La API REST se desarrollo con .Net Core 8, utilizando una arquitectura DDD con CQRS. Y EntityFrameworkCore como ORM para la base de datos SQL Server.

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
- Validaciones en la API. Por ejemplo, si se quiere dar de alta un permiso con un PermissionType que no existe, lo indique con un 400 (Bad Request) y su detalle.

Si bien, no se pedia, me hubiese gustado agregar:

- En el front:
  - Utilizar i18Next para manejar multilenguaje
  - Agregar un selector de temas
  - Notificar la finalización de una acción (correcta o incorrecta)
- En la API:
  - Utilizar una base de datos como MongoDB para almacenar los eventos, y así poder trabajar bien con DDD y Event Sourcing
- Con ElasticSearch:
  - Agregar Kibana

Además de mejorar la documentación, agregando diagramas y más detalle en este readme.
