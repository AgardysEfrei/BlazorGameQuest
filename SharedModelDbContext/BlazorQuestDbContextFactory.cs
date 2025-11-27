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
            var optionsBuilder = new DbContextOptionsBuilder<BlazorQuestDbContext>();
            
            var connectionString = "Host=db;Port=5432;Database=blazorgamequest;Username=postgres;Password=postgres;";
            
            optionsBuilder.UseNpgsql(connectionString);

            return new BlazorQuestDbContext(optionsBuilder.Options);
        }
    }
}