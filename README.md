# BlazorGameQuest
Projet DOTNET Théo Klein / Vicente Seixas
# Pour la première utilisation :
- Lancer uniquement le docker de base de données appelé "db" avec cette commande : 
`docker-compose up -d db`


- Puis déplacez vous dans le projet "SharedModelDbContext" avec la commande `cd .\SharedModelDbContext\`


- et enfin exécutez la commande suivante :
`dotnet ef database update --verbose --project SharedModelDbContext.csproj   --startup-project SharedModelDbContext.csproj`


- Voilà, vous pouvez désormais utiliser la commande : `docker-compose up -d` pour lancer le projet.
## Build & Run
In order to build and run the application, you first have to change the following environnment variable to the path where you wish to store the database data:

`POSTGRES_DATA`

then run the following command:

`docker compose -f compose.yaml up -d`

Finally, you can connect to http://localhost:5000/ to access the webapp. 

Url swagger : http://localhost:5001/index.html