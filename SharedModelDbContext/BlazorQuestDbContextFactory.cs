using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SharedModelDbContext
{
    // Cette classe implémente l'interface IDesignTimeDbContextFactory
    // pour indiquer aux outils dotnet ef comment créer le DbContext.
    public class BlazorQuestDbContextFactory : IDesignTimeDbContextFactory<BlazorQuestDbContext>
    {
        public BlazorQuestDbContext CreateDbContext(string[] args)
        {
            // 1. Configuration: Nécessaire pour lire la chaîne de connexion
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                // Si votre chaîne de connexion est dans appsettings.json, lisez-la.
                // NOTE: Assurez-vous que appsettings.json est copié dans le répertoire de travail
                // lors de l'exécution de la commande dotnet ef (voir note après le fichier).
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // 2. Création du DbContextOptionsBuilder
            var optionsBuilder = new DbContextOptionsBuilder<BlazorQuestDbContext>();
            
            // --- Logique pour obtenir la chaîne de connexion ---
            // Dans un environnement réel de Design-Time, EF Core ne sait pas toujours 
            // où chercher la chaîne de connexion. Nous devons la lui donner.
            
            // NOTE: Remplacez cette ligne par la façon dont vous obtenez la chaîne
            // Si la chaîne est en dur, vous pouvez la mettre ici temporairement:
            // var connectionString = "Host=db;Port=5432;Database=blazorgamequest;Username=root;Password=root;";
            
            // Si vous utilisez appsettings.json, utilisez :
            var connectionString = configuration.GetConnectionString("BlazorQuestDbConnection");

            // Pour l'exemple, utilisons la configuration en dur pour l'instant:
            if (string.IsNullOrEmpty(connectionString))
            {
                // FALLBACK si la config n'est pas lue
                connectionString = "Host=localhost;Port=5432;Database=blazorgamequest;Username=root;Password=root;";
            }

            // 3. Application de l'option Npgsql
            optionsBuilder.UseNpgsql(connectionString);

            // 4. Retourne la nouvelle instance du DbContext
            return new BlazorQuestDbContext(optionsBuilder.Options);
        }
    }
}