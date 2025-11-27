namespace SharedModelDbContext;
using Microsoft.EntityFrameworkCore;
public class BlazorQuestDbContext : DbContext
{
    public DbSet<SharedModels.Administrateur> Administrateurs { get; set; }
    public DbSet<SharedModels.Donjons> DonjonsEnumerable { get; set; }
    public DbSet<SharedModels.Joueur> Joueurs { get; set; }
    public DbSet<SharedModels.Monstre> Monstres { get; set; }
    public DbSet<SharedModels.Salles> SallesEnumerable { get; set; }
    public DbSet<SharedModels.ScorePartie> ScoreParties { get; set; }
    public DbSet<SharedModels.Utilisateur> Utilisateurs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //COnfiguration explicite de la relation N-N des tables Monstre et Salles
        modelBuilder.Entity<SharedModels.Monstre>()
            .HasOne(e => e.salle)
            .WithOne(e => e.monstre)
            .HasForeignKey<SharedModels.Monstre>(e => e.salleid)
            .IsRequired();
        modelBuilder.Entity<SharedModels.ScorePartie>()
            .HasKey(a => a.joueurId);
        modelBuilder.Entity<SharedModels.Salles>()
            .HasKey(a => a.salleId);
        modelBuilder.Entity<SharedModels.Administrateur>()
            .Property(f=>f.administrateurid)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<SharedModels.Donjons>()
            .Property(f=>f.donjonsid)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<SharedModels.Joueur>()
            .Property(f=>f.joueurid)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<SharedModels.Monstre>()
            .Property(f=>f.monstreid)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<SharedModels.Salles>()
            .Property(f=>f.salleId)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<SharedModels.Utilisateur>()
            .Property(f=>f.utilisateurId)
            .ValueGeneratedOnAdd();
        
        base.OnModelCreating(modelBuilder); 
        
        modelBuilder.HasDefaultSchema("blazorgame");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=db;Port=5432;Database=blazorgamequest;Username=postgres;Password=postgres;"); // chaine de connexion à la DB
    }
    public BlazorQuestDbContext(DbContextOptions<BlazorQuestDbContext> options) : base(options)
    {
        // Le corps de la fonction est généralement vide,
        // car le travail est fait par l'appel à la base class 'base(options)'.
    }
    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SharedModels.Administrateur>()
            .HasKey(a => a.Administrateurid);
        modelBuilder.Entity<SharedModels.Administrateur>()
            .Property(a => a.Administrateurid)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<SharedModels.Administrateur>()
            .HasOne(a=>a.Utilisateur)
            .WithOne(b=>b.Administrateur)
            .HasForeignKey<SharedModels.Utilisateur>(a=>a.UtilisateurId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }*/
}