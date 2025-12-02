using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SharedModelDbContext.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "blazorgame");

            migrationBuilder.CreateTable(
                name: "Donjons",
                schema: "blazorgame",
                columns: table => new
                {
                    donjonsid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donjons", x => x.donjonsid);
                });

            migrationBuilder.CreateTable(
                name: "Monstres",
                schema: "blazorgame",
                columns: table => new
                {
                    monstreid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    lienImage = table.Column<string>(type: "text", nullable: false),
                    pointDeVie = table.Column<int>(type: "integer", nullable: false),
                    chanceToucher = table.Column<double>(type: "double precision", nullable: false),
                    pointGagner = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monstres", x => x.monstreid);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                schema: "blazorgame",
                columns: table => new
                {
                    utilisateurId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom = table.Column<string>(type: "text", nullable: false),
                    prenom = table.Column<string>(type: "text", nullable: false),
                    adresseMail = table.Column<string>(type: "text", nullable: false),
                    motDePasse = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.utilisateurId);
                });

            migrationBuilder.CreateTable(
                name: "Salles",
                schema: "blazorgame",
                columns: table => new
                {
                    salleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scoreBonus = table.Column<double>(type: "double precision", nullable: false),
                    monstreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salles", x => x.salleId);
                    table.ForeignKey(
                        name: "FK_Salles_Monstres_monstreId",
                        column: x => x.monstreId,
                        principalSchema: "blazorgame",
                        principalTable: "Monstres",
                        principalColumn: "monstreid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administrateurs",
                schema: "blazorgame",
                columns: table => new
                {
                    administrateurid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    utilisateurId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrateurs", x => x.administrateurid);
                    table.ForeignKey(
                        name: "FK_Administrateurs_Utilisateurs_utilisateurId",
                        column: x => x.utilisateurId,
                        principalSchema: "blazorgame",
                        principalTable: "Utilisateurs",
                        principalColumn: "utilisateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Joueurs",
                schema: "blazorgame",
                columns: table => new
                {
                    joueurid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    utilisateurId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueurs", x => x.joueurid);
                    table.ForeignKey(
                        name: "FK_Joueurs_Utilisateurs_utilisateurId",
                        column: x => x.utilisateurId,
                        principalSchema: "blazorgame",
                        principalTable: "Utilisateurs",
                        principalColumn: "utilisateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonjonsSalles",
                schema: "blazorgame",
                columns: table => new
                {
                    donjonsListdonjonsid = table.Column<int>(type: "integer", nullable: false),
                    sallesListsalleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonjonsSalles", x => new { x.donjonsListdonjonsid, x.sallesListsalleId });
                    table.ForeignKey(
                        name: "FK_DonjonsSalles_Donjons_donjonsListdonjonsid",
                        column: x => x.donjonsListdonjonsid,
                        principalSchema: "blazorgame",
                        principalTable: "Donjons",
                        principalColumn: "donjonsid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonjonsSalles_Salles_sallesListsalleId",
                        column: x => x.sallesListsalleId,
                        principalSchema: "blazorgame",
                        principalTable: "Salles",
                        principalColumn: "salleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoreParties",
                schema: "blazorgame",
                columns: table => new
                {
                    ScorePartieId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    joueurId = table.Column<int>(type: "integer", nullable: false),
                    score = table.Column<double>(type: "double precision", nullable: false),
                    progression = table.Column<int>(type: "integer", nullable: false),
                    pointsDeVie = table.Column<int>(type: "integer", nullable: false),
                    partieTerminee = table.Column<bool>(type: "boolean", nullable: false),
                    donjonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreParties", x => x.ScorePartieId);
                    table.ForeignKey(
                        name: "FK_ScoreParties_Donjons_donjonId",
                        column: x => x.donjonId,
                        principalSchema: "blazorgame",
                        principalTable: "Donjons",
                        principalColumn: "donjonsid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreParties_Joueurs_joueurId",
                        column: x => x.joueurId,
                        principalSchema: "blazorgame",
                        principalTable: "Joueurs",
                        principalColumn: "joueurid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "blazorgame",
                table: "Monstres",
                columns: new[] { "monstreid", "chanceToucher", "description", "lienImage", "nom", "pointDeVie", "pointGagner" },
                values: new object[,]
                {
                    { 1, 30.5, "Alien venu de l'univers pour enlever une princesse sur la planète terre. Extrêment rapide mais faible", "../BlazorAppApi/wwwroot/alien.jpeg", "tatunga", 9, 4.5 },
                    { 2, 90.5, "Cambrioleur qui cambriole des donjons, précis mais lent", "../BlazorAppApi/wwwroot/cambrioleur.png", "Cambrioleur", 20, 45.0 },
                    { 3, 10.5, "Empereur ayant la volonté d'assujetir la terre, TRES résistant mais vise très mal. Vous devriez fuir le combat", "../BlazorAppApi/wwwroot/alien.jpg", "empereur_de_lespace", 100, 450.0 },
                    { 4, 100.0, "Enfant s'étant perdu dans le donjon, très facile à battre et donne beaucoup d'expérience. Mais franchement, qui serait assez cruel pour se battre avec un enfant ?", "../BlazorAppApi/wwwroot/garcon_effrayant.jpg", "garçon_effrayant", 1, 500.0 },
                    { 5, 90.0, "Juste un type avec un flingue, le frapper sera facile et pour vous et pour lui", "../BlazorAppApi/wwwroot/homme_avec_une_arme.jpg", "Homme avec une arme", 40, 290.0 },
                    { 6, 70.0, "Le pire ennemi de tout le monde, entrainé par des années d'attaque de mauvais payeurs, il n'aura aucun mal à vous rendre la monnaie de votre pièce", "../BlazorAppApi/wwwroot/inspecteur_impot.jpg", "inspecteur_impot", 35, 100.0 },
                    { 7, 60.0, "Mechant qui veut tuer la gentille parce que c'est le méchant ni plus ni moins", "../BlazorAppApi/wwwroot/mechant_qui_veut_tuer_la_gentille.jpg", "mechant_qui_veut_tuer_la_gentille", 40, 200.0 },
                    { 8, 50.0, "Souris qui aime beaucoup noel, avec lui c'est 50/50", "../BlazorAppApi/wwwroot/mickey_mouse.gif", "mickey_mouse", 50, 500.0 },
                    { 9, 20.0, "Homme très violent et ératique. Mieux vaux ne pas l'énerver", "../BlazorAppApi/wwwroot/mister_frog.jpeg", "Mister Frog", 200, 500.0 },
                    { 10, 70.0, "WAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAALUIGI TIME!!!!!!!!!!!!!!!!!!", "../BlazorAppApi/wwwroot/waluigi.jpg", "waluigi", 70, 190.0 }
                });

            migrationBuilder.InsertData(
                schema: "blazorgame",
                table: "Utilisateurs",
                columns: new[] { "utilisateurId", "adresseMail", "motDePasse", "nom", "prenom" },
                values: new object[] { 20, "Test@Test.com", "Test", "Test", "Test" });

            migrationBuilder.InsertData(
                schema: "blazorgame",
                table: "Joueurs",
                columns: new[] { "joueurid", "utilisateurId" },
                values: new object[] { 20, 20 });

            migrationBuilder.InsertData(
                schema: "blazorgame",
                table: "Salles",
                columns: new[] { "salleId", "monstreId", "scoreBonus" },
                values: new object[,]
                {
                    { 10, 1, 230.0 },
                    { 20, 2, -300.0 },
                    { 30, 3, 400.0 },
                    { 40, 4, -230.0 },
                    { 50, 5, 90.0 },
                    { 60, 6, 230.0 },
                    { 70, 7, 10.0 },
                    { 80, 8, -30.0 },
                    { 90, 9, -247.0 },
                    { 100, 10, -300.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrateurs_utilisateurId",
                schema: "blazorgame",
                table: "Administrateurs",
                column: "utilisateurId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonjonsSalles_sallesListsalleId",
                schema: "blazorgame",
                table: "DonjonsSalles",
                column: "sallesListsalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Joueurs_utilisateurId",
                schema: "blazorgame",
                table: "Joueurs",
                column: "utilisateurId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salles_monstreId",
                schema: "blazorgame",
                table: "Salles",
                column: "monstreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScoreParties_donjonId",
                schema: "blazorgame",
                table: "ScoreParties",
                column: "donjonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScoreParties_joueurId",
                schema: "blazorgame",
                table: "ScoreParties",
                column: "joueurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrateurs",
                schema: "blazorgame");

            migrationBuilder.DropTable(
                name: "DonjonsSalles",
                schema: "blazorgame");

            migrationBuilder.DropTable(
                name: "ScoreParties",
                schema: "blazorgame");

            migrationBuilder.DropTable(
                name: "Salles",
                schema: "blazorgame");

            migrationBuilder.DropTable(
                name: "Donjons",
                schema: "blazorgame");

            migrationBuilder.DropTable(
                name: "Joueurs",
                schema: "blazorgame");

            migrationBuilder.DropTable(
                name: "Monstres",
                schema: "blazorgame");

            migrationBuilder.DropTable(
                name: "Utilisateurs",
                schema: "blazorgame");
        }
    }
}
