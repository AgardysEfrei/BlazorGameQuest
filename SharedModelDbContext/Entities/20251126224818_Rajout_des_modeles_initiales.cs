using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SharedModelDbContext.Entities
{
    /// <inheritdoc />
    public partial class Rajout_des_modeles_initiales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "blazorgame",
                table: "SallesEnumerable",
                columns: new[] { "salleId", "scoreBonus" },
                values: new object[,]
                {
                    { 10, 230.0 },
                    { 20, -300.0 },
                    { 30, 400.0 },
                    { 40, -230.0 },
                    { 50, 90.0 },
                    { 60, 230.0 },
                    { 70, 10.0 },
                    { 80, -30.0 },
                    { 90, -247.0 },
                    { 100, -300.0 }
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
                table: "Monstres",
                columns: new[] { "monstreid", "chanceToucher", "description", "lienImage", "nom", "pointDeVie", "pointGagner", "salleid" },
                values: new object[,]
                {
                    { 1, 30.5, "Alien venu de l'univers pour enlever une princesse sur la planète terre. Extrêment rapide mais faible", "../BlazorAppApi/wwwroot/alien.jpeg", "tatunga", 9, 4.5, 10 },
                    { 2, 90.5, "Cambrioleur qui cambriole des donjons, précis mais lent", "../BlazorAppApi/wwwroot/cambrioleur.png", "Cambrioleur", 20, 45.0, 20 },
                    { 3, 10.5, "Empereur ayant la volonté d'assujetir la terre, TRES résistant mais vise très mal. Vous devriez fuir le combat", "../BlazorAppApi/wwwroot/alien.jpg", "empereur_de_lespace", 100, 450.0, 30 },
                    { 4, 100.0, "Enfant s'étant perdu dans le donjon, très facile à battre et donne beaucoup d'expérience. Mais franchement, qui serait assez cruel pour se battre avec un enfant ?", "../BlazorAppApi/wwwroot/garcon_effrayant.jpg", "garçon_effrayant", 1, 500.0, 40 },
                    { 5, 90.0, "Juste un type avec un flingue, le frapper sera facile et pour vous et pour lui", "../BlazorAppApi/wwwroot/homme_avec_une_arme.jpg", "Homme avec une arme", 40, 290.0, 50 },
                    { 6, 70.0, "Le pire ennemi de tout le monde, entrainé par des années d'attaque de mauvais payeurs, il n'aura aucun mal à vous rendre la monnaie de votre pièce", "../BlazorAppApi/wwwroot/inspecteur_impot.jpg", "inspecteur_impot", 35, 100.0, 60 },
                    { 7, 60.0, "Mechant qui veut tuer la gentille parce que c'est le méchant ni plus ni moins", "../BlazorAppApi/wwwroot/mechant_qui_veut_tuer_la_gentille.jpg", "mechant_qui_veut_tuer_la_gentille", 40, 200.0, 70 },
                    { 8, 50.0, "Souris qui aime beaucoup noel, avec lui c'est 50/50", "../BlazorAppApi/wwwroot/mickey_mouse.gif", "mickey_mouse", 50, 500.0, 80 },
                    { 9, 20.0, "Homme très violent et ératique. Mieux vaux ne pas l'énerver", "../BlazorAppApi/wwwroot/mister_frog.jpeg", "Mister Frog", 200, 500.0, 90 },
                    { 10, 70.0, "WAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAALUIGI TIME!!!!!!!!!!!!!!!!!!", "../BlazorAppApi/wwwroot/waluigi.jpg", "waluigi", 70, 190.0, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "Joueurs",
                keyColumn: "joueurid",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "SallesEnumerable",
                keyColumn: "salleId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "SallesEnumerable",
                keyColumn: "salleId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "SallesEnumerable",
                keyColumn: "salleId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "SallesEnumerable",
                keyColumn: "salleId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "SallesEnumerable",
                keyColumn: "salleId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "SallesEnumerable",
                keyColumn: "salleId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "SallesEnumerable",
                keyColumn: "salleId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "SallesEnumerable",
                keyColumn: "salleId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "SallesEnumerable",
                keyColumn: "salleId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "SallesEnumerable",
                keyColumn: "salleId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "Utilisateurs",
                keyColumn: "utilisateurId",
                keyValue: 20);
        }
    }
}
