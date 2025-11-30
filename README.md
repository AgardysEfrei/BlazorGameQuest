# BlazorGameQuest
Projet DOTNET Théo Klein / Vicente Seixas

## Build & Run
In order to build and run the application, you first have to change the following environnment variable to the path where you wish to store the database data:

`POSTGRES_DATA` defined in `.env`

then run the following command:

`docker compose -f compose.yaml up -d --build`

Finally, you can connect to http://localhost:5000/ to access the webapp. 

Swagger URL : http://localhost:5001/index.html