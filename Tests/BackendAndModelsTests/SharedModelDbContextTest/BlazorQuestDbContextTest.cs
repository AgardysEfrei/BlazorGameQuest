using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using SharedModels; // Vos modèles Administrateur, Donjons, Joueur, Monstre, Salles, etc.
using SharedModelDbContext; // Namespace contenant BlazorQuestDbContext
using System;
using System.Linq;

// NOTE: Assurez-vous d'avoir les dépendances NuGet : 
// - Microsoft.EntityFrameworkCore.InMemory
// - Microsoft.VisualStudio.TestTools.UnitTesting

namespace MonApplication.Tests
{
    [TestClass]
    public class BlazorQuestDbContextTests
    {
        private DbContextOptions<BlazorQuestDbContext> _options;

        [TestInitialize]
        public void Setup()
        {
            // Configuration de l'option In-Memory pour simuler la base de données.
            // Utilisation de UseInMemoryDatabase(nom) pour garantir une isolation complète.
            // En utilisant un GUID unique, chaque test utilise une base de données distincte.
            _options = new DbContextOptionsBuilder<BlazorQuestDbContext>()
                .UseInMemoryDatabase(databaseName: $"BlazorQuestDb_{Guid.NewGuid()}")
                .Options;
        }

        // --- TESTS DE BASE DU CONTEXTE ET DES CLÉS PRIMAIRES ---
        
        [TestMethod]
        public void BlazorQuestDbContext_CanBeCreated_WithInMemoryDatabase()
        {
            // ACT
            using (var context = new BlazorQuestDbContext(_options))
            {
                // ASSERT
                // Vérifie que la création du contexte n'a pas levé d'exception et que les DbSet sont accessibles.
                Assert.IsNotNull(context.Utilisateurs);
                Assert.IsNotNull(context.Donjons);
                Assert.IsNotNull(context.Monstres);
            }
        }
        }
    }