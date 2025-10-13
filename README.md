# BlazorGameQuest
Projet DOTNET Théo Klein / Vicente Seixas

## Build & Run
In order to build and run the application, you first have to change the following environnment variable to the path where you wish to store the database data:

`POSTGRES_DATA`

then run the following command:

`docker compose -f compose.yaml up -d`

Finally, you can connect to http://localhost:50045/ to access the webapp.

Swagger is accessible at http://localhost:50045/swagger/index.html  

## Microservices

Service | Role
-------|-------
BlazorApp | Frontend
Gateway | Rest API, entrypoint for the backend
AuthentificationService | User authentification with keycloak
GameService | Handle all game activities
ScoreService | handle players scores
UserService | handle users data

