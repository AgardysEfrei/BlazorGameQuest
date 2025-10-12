# BlazorGameQuest
Projet DOTNET Théo Klein / Vicente Seixas

## Build & Run
In order to build and run the application, you first have to run the following command:

`docker compose -f compose.yml up -d`

Then, you can connect to http://localhost:50045/ to access the webapp.

## Microservices

Service | Role
-------|-------
BlazorApp | Frontend
AuthentificationService | User authentification with keycloak
GameService | Handle all game activities
ScoreService | handle players scores
UserService | handle users data

