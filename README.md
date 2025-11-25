# BlazorGameQuest
Projet DOTNET Théo Klein / Vicente Seixas

## Build & Run
In order to build and run the application, you first have to change the following environnment variable to the path where you wish to store the database data:

`POSTGRES_DATA`

then run the following command:

`docker compose -f compose.yaml up -d`

Finally, you can connect to http://localhost:50045/ to access the webapp.

Swagger is accessible at http://localhost:50045/swagger/index.html  

Url swagger : http://localhost:5001/index.html

Pour la migration merci d'utiliser la chaîne de connexion suivante :
"Host=localhost;Port=5432;Database=blazorgamequest;Username=root;Password=root;"

Pour la première utilisation :
Lancer uniquement le docker de base de données "appelé db-1".
Puis déplacez vous dans le projet "SharedModelDbContext"
et enfin exécutez la commande suivante :
dotnet ef database update --verbose --project SharedModelDbContext.csproj   --startup-project SharedModelDbContext.csproj
Et enfin, faites la migration
## Microservices

Service | Role
-------|-------
BlazorApp | Frontend
Gateway | Rest API, entrypoint for the backend
AuthentificationService | User authentification with keycloak
GameService | Handle all game activities
ScoreService | handle players scores
UserService | handle users data

