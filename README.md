# TareasApi

API para gestionar tareas con operaciones CRUD usando .NET Core

## Requisitos

- .NET Core SDK 6.0 o superior

## Configuración

1. Clona el repositorio:
   ```bash
   git clone https://github.com/OrlanDelgado/APITesting/tree/master
   cd TareasApi

2. Descargar la aplicacion del repositorio y a su vez descargar la aplicacion del front-end alojada en el siguiente repositorio:

https://github.com/OrlanDelgado/react-app-spring.git

montar ambas aplicaciones repositorio en el docker-desktop

ejecutar.


Crear la base de datos en la MongoDb

use TareasDb

db.createCollection("tareas")

db.tareas.insertOne({ _id: ObjectId("667cbadb066fdec9ff7638a2"), Titulo: "Tarea de ejemplo", Descripcion: "Descripción de ejemplo", FechaCreacion: ISODate("2024-06-27"), Estado: "completado" })


Una vez este lista la base de datos, acceder a la url http://localhost:3000 para ver la aplicacion en ejecución.


