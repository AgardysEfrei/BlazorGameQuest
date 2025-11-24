using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharedModelDbContext.Entities
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonjonsEnumerable",
                columns: table => new
                {
                    donjonsid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonjonsEnumerable", x => x.donjonsid);
                });

            migrationBuilder.CreateTable(
                name: "SallesEnumerable",
                columns: table => new
                {
                    salleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SallesEnumerable", x => x.salleId);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    prenom = table.Column<string>(type: "TEXT", nullable: false),
                    adresseMail = table.Column<string>(type: "TEXT", nullable: false),
                    motDePasse = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.utilisateurId);
                });

            migrationBuilder.CreateTable(
                name: "DonjonsSalles",
                columns: table => new
                {
                    donjonsListdonjonsid = table.Column<int>(type: "INTEGER", nullable: false),
                    sallesListsalleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonjonsSalles", x => new { x.donjonsListdonjonsid, x.sallesListsalleId });
                    table.ForeignKey(
                        name: "FK_DonjonsSalles_DonjonsEnumerable_donjonsListdonjonsid",
                        column: x => x.donjonsListdonjonsid,
                        principalTable: "DonjonsEnumerable",
                        principalColumn: "donjonsid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonjonsSalles_SallesEnumerable_sallesListsalleId",
                        column: x => x.sallesListsalleId,
                        principalTable: "SallesEnumerable",
                        principalColumn: "salleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monstres",
                columns: table => new
                {
                    monstreid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    salleid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monstres", x => x.monstreid);
                    table.ForeignKey(
                        name: "FK_Monstres_SallesEnumerable_salleid",
                        column: x => x.salleid,
                        principalTable: "SallesEnumerable",
                        principalColumn: "salleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administrateurs",
                columns: table => new
                {
                    administrateurid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrateurs", x => x.administrateurid);
                    table.ForeignKey(
                        name: "FK_Administrateurs_Utilisateurs_utilisateurId",
                        column: x => x.utilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "utilisateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Joueurs",
                columns: table => new
                {
                    joueurid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueurs", x => x.joueurid);
                    table.ForeignKey(
                        name: "FK_Joueurs_Utilisateurs_utilisateurId",
                        column: x => x.utilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "utilisateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoreParties",
                columns: table => new
                {
                    joueurId = table.Column<int>(type: "INTEGER", nullable: false),
                    score = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreParties", x => x.joueurId);
                    table.ForeignKey(
                        name: "FK_ScoreParties_Joueurs_joueurId",
                        column: x => x.joueurId,
                        principalTable: "Joueurs",
                        principalColumn: "joueurid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrateurs_utilisateurId",
                table: "Administrateurs",
                column: "utilisateurId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonjonsSalles_sallesListsalleId",
                table: "DonjonsSalles",
                column: "sallesListsalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Joueurs_utilisateurId",
                table: "Joueurs",
                column: "utilisateurId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monstres_salleid",
                table: "Monstres",
                column: "salleid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrateurs");

            migrationBuilder.DropTable(
                name: "DonjonsSalles");

            migrationBuilder.DropTable(
                name: "Monstres");

            migrationBuilder.DropTable(
                name: "ScoreParties");

            migrationBuilder.DropTable(
                name: "DonjonsEnumerable");

            migrationBuilder.DropTable(
                name: "SallesEnumerable");

            migrationBuilder.DropTable(
                name: "Joueurs");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
