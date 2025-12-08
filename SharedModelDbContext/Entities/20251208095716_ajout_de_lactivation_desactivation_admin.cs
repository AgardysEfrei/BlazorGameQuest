using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharedModelDbContext.Entities
{
    /// <inheritdoc />
    public partial class ajout_de_lactivation_desactivation_admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "estActive",
                schema: "blazorgame",
                table: "Utilisateurs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 5,
                column: "lienImage",
                value: "homme_avec_une_arme.jpeg");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Utilisateurs",
                keyColumn: "utilisateurId",
                keyValue: 20,
                column: "estActive",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estActive",
                schema: "blazorgame",
                table: "Utilisateurs");

            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 5,
                column: "lienImage",
                value: "homme_avec_une_arme.jpg");
        }
    }
}
