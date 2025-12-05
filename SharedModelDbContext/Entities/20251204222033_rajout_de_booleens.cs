using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharedModelDbContext.Entities
{
    /// <inheritdoc />
    public partial class rajout_de_booleens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 1,
                column: "lienImage",
                value: "alien.jpeg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 2,
                column: "lienImage",
                value: "cambrioleur.png");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 3,
                column: "lienImage",
                value: "empereur_espace.jpg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 4,
                column: "lienImage",
                value: "garcon_effrayant.jpg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 5,
                column: "lienImage",
                value: "homme_avec_une_arme.jpg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 6,
                column: "lienImage",
                value: "inspecteur_impot.jpg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 7,
                column: "lienImage",
                value: "mechant_qui_veut_tuer_la_gentille.jpg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 8,
                column: "lienImage",
                value: "mickey_mouse.gif");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 9,
                column: "lienImage",
                value: "mister_frog.jpeg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 10,
                column: "lienImage",
                value: "waluigi.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 1,
                column: "lienImage",
                value: "../BlazorAppApi/wwwroot/alien.jpeg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 2,
                column: "lienImage",
                value: "../BlazorAppApi/wwwroot/cambrioleur.png");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 3,
                column: "lienImage",
                value: "../BlazorAppApi/wwwroot/alien.jpg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 4,
                column: "lienImage",
                value: "../BlazorAppApi/wwwroot/garcon_effrayant.jpg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 5,
                column: "lienImage",
                value: "../BlazorAppApi/wwwroot/homme_avec_une_arme.jpg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 6,
                column: "lienImage",
                value: "../BlazorAppApi/wwwroot/inspecteur_impot.jpg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 7,
                column: "lienImage",
                value: "../BlazorAppApi/wwwroot/mechant_qui_veut_tuer_la_gentille.jpg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 8,
                column: "lienImage",
                value: "../BlazorAppApi/wwwroot/mickey_mouse.gif");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 9,
                column: "lienImage",
                value: "../BlazorAppApi/wwwroot/mister_frog.jpeg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 10,
                column: "lienImage",
                value: "../BlazorAppApi/wwwroot/waluigi.jpg");
        }
    }
}
