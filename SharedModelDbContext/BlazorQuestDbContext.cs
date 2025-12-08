using Microsoft.Extensions.DependencyInjection;
using SharedModels;

namespace SharedModelDbContext;
using Microsoft.EntityFrameworkCore;
public class BlazorQuestDbContext : DbContext
{
    public DbSet<SharedModels.Administrateur> Administrateurs { get; set; }
    public DbSet<SharedModels.Donjons> Donjons { get; set; }
    public DbSet<SharedModels.Joueur> Joueurs { get; set; }
    public DbSet<SharedModels.Monstre> Monstres { get; set; }
    public DbSet<SharedModels.Salles> Salles { get; set; }
    public DbSet<SharedModels.ScorePartie> ScoreParties { get; set; }
    public DbSet<SharedModels.Utilisateur> Utilisateurs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configuration explicite de la relation N-N des tables Monstre et Salles
        modelBuilder.Entity<SharedModels.ScorePartie>()
            .HasKey(a => a.ScorePartieId);

        modelBuilder.Entity<SharedModels.Salles>()
            .HasKey(a => a.salleId);
        modelBuilder.Entity<SharedModels.Salles>()
            .HasData(
                new Salles()
                {
                    salleId = 10,
                    scoreBonus = 230,
                    monstreId = 1,

                },
                new Salles()
                {
                    salleId = 20,
                    scoreBonus = -300,
                    monstreId = 2
                    
                },
                new Salles()
                {
                    salleId = 30,
                    scoreBonus = 400,
                    monstreId = 3
                },
                new Salles()
                {
                    salleId = 40,
                    scoreBonus = -230,
                    monstreId = 4

                },
                new Salles()
                {
                    salleId = 50,
                    scoreBonus = 90,
                    monstreId = 5
                    
                },
                new Salles()
                {
                    salleId = 60,
                    scoreBonus = 230,
                    monstreId = 6
                },
                new Salles()
                {
                    salleId = 70,
                    scoreBonus = 10,
                    monstreId = 7

                },
                new Salles()
                {
                    salleId = 80,
                    scoreBonus = -30,
                    monstreId = 8
                    
                },
                new Salles()
                {
                    salleId = 90,
                    scoreBonus = -247,
                    monstreId = 9
                },
                new Salles()
                {
                    salleId = 100,
                    scoreBonus = -300,
                    monstreId = 10
                    
                })
            ;
        modelBuilder.Entity<SharedModels.Monstre>()
            .HasKey(f=>f.monstreid);
        modelBuilder.Entity<SharedModels.Administrateur>()
            .Property(f=>f.administrateurid)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Administrateur>()
            .HasData(
            new Administrateur()
            {
                administrateurid = 50,
                utilisateurId = 40
            }
            );
        modelBuilder.Entity<SharedModels.Donjons>()
            .Property(f=>f.donjonsid)
            .ValueGeneratedOnAdd();
        //Configurer explicitement la clef étrangère de scorePartie
        modelBuilder.Entity<Donjons>()
            .HasOne(e => e.scorePartie)
            .WithOne(e => e.donjonGenere)
            .HasForeignKey<ScorePartie>(e => e.donjonId)
            .IsRequired();
        modelBuilder.Entity<SharedModels.Utilisateur>()
            .Property(f=>f.utilisateurId)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<SharedModels.Utilisateur>()
            .HasData(
                new Utilisateur()
                {
                    utilisateurId = 20,
                    nom = "Test",
                    prenom = "Test",
                    adresseMail = "Test@Test.com",
                    motDePasse = "Test"

                },
                new Utilisateur()
                {
                    utilisateurId = 40,
                    nom = "Admin",
                    prenom = "DeTest",
                    adresseMail = "testadmin@admin.com",
                    motDePasse = "Admin"
                }
                )
            ;
        modelBuilder.Entity<SharedModels.Joueur>()
            .Property(f=>f.joueurid)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<SharedModels.Joueur>()
            .HasData(
                new Joueur()
                {
                    joueurid = 20,
                    utilisateurId = 20,
                });
        modelBuilder.Entity<SharedModels.Monstre>()
            .HasData(
                new Monstre()
                {
                    monstreid = 1,
                    nom = "tatunga",
                    description =
                        "Alien venu de l'univers pour enlever une princesse sur la planète terre. Extrêment rapide mais faible",
                    lienImage = "alien.jpeg",
                    pointDeVie = 9,
                    chanceToucher = 30.5,
                    pointGagner = 4.5,
                },
                new Monstre()
                {
                    monstreid = 2,
                    nom = "Cambrioleur",
                    description =
                        "Cambrioleur qui cambriole des donjons, précis mais lent",
                    lienImage = "cambrioleur.png",
                    pointDeVie = 20,
                    chanceToucher = 90.5,
                    pointGagner = 45,
                },
                new Monstre()
                {
                    monstreid = 3,
                    nom = "empereur_de_lespace",
                    description =
                        "Empereur ayant la volonté d'assujetir la terre, TRES résistant mais vise très mal. Vous devriez fuir le combat",
                    lienImage = "empereur_espace.jpg",
                    pointDeVie = 100,
                    chanceToucher = 10.5,
                    pointGagner = 450,
                },
                new Monstre()
                {
                    monstreid = 4,
                    nom = "garçon_effrayant",
                    description =
                        "Enfant s'étant perdu dans le donjon, très facile à battre et donne beaucoup d'expérience. Mais franchement, qui serait assez cruel pour se battre avec un enfant ?",
                    lienImage = "garcon_effrayant.jpg",
                    pointDeVie = 1,
                    chanceToucher = 100,
                    pointGagner = 500,
                },
                new Monstre()
                {
                    monstreid = 5,
                    nom = "Homme avec une arme",
                    description =
                        "Juste un type avec un flingue, le frapper sera facile et pour vous et pour lui",
                    lienImage = "homme_avec_une_arme.jpeg",
                    pointDeVie = 40,
                    chanceToucher = 90,
                    pointGagner = 290,
                },
                new Monstre()
                {
                    monstreid = 6,
                    nom = "inspecteur_impot",
                    description =
                        "Le pire ennemi de tout le monde, entrainé par des années d'attaque de mauvais payeurs, il n'aura aucun mal à vous rendre la monnaie de votre pièce",
                    lienImage = "inspecteur_impot.jpg",
                    pointDeVie = 35,
                    chanceToucher = 70,
                    pointGagner = 100,
                },new Monstre()
                {
                    monstreid = 7,
                    nom = "mechant_qui_veut_tuer_la_gentille",
                    description =
                        "Mechant qui veut tuer la gentille parce que c'est le méchant ni plus ni moins",
                    lienImage = "mechant_qui_veut_tuer_la_gentille.png",
                    pointDeVie = 40,
                    chanceToucher = 60,
                    pointGagner = 200,
                },
                new Monstre()
                {
                    monstreid = 8,
                    nom = "mickey_mouse",
                    description =
                        "Souris qui aime beaucoup noel, avec lui c'est 50/50",
                    lienImage = "mickey_mouse.gif",
                    pointDeVie = 50,
                    chanceToucher = 50,
                    pointGagner = 500,
                },
                new Monstre()
                {
                    monstreid = 9,
                    nom = "Mister Frog",
                    description =
                        "Homme très violent et ératique. Mieux vaux ne pas l'énerver",
                    lienImage = "mister_frog.jpeg",
                    pointDeVie = 200,
                    chanceToucher = 20,
                    pointGagner = 500,
                },
                new Monstre()
                {
                    monstreid = 10,
                    nom = "waluigi",
                    description =
                        "WAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAALUIGI TIME!!!!!!!!!!!!!!!!!!",
                    lienImage = "waluigi.jpg",
                    pointDeVie = 70,
                    chanceToucher = 70,
                    pointGagner = 190,
                });
        modelBuilder.Entity<SharedModels.Monstre>()
            .Property(f=>f.monstreid)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<SharedModels.Salles>()
            .Property(f=>f.salleId)
            .ValueGeneratedOnAdd();
        
        base.OnModelCreating(modelBuilder); 
        
        modelBuilder.HasDefaultSchema("blazorgame");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=host.docker.internal;Port=5432;Database=blazorgamequest;Username=postgres;Password=postgres;"); // chaine de connexion à la DB
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