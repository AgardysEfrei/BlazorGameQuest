using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharedModelDbContext.Entities
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "blazorgame",
                table: "Utilisateurs",
                columns: new[] { "utilisateurId", "adresseMail", "estActive", "motDePasse", "nom", "prenom" },
                values: new object[] { 40, "testadmin@admin.com", true, "Admin", "Admin", "DeTest" });

            migrationBuilder.InsertData(
                schema: "blazorgame",
                table: "Administrateurs",
                columns: new[] { "administrateurid", "utilisateurId" },
                values: new object[] { 50, 40 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "Administrateurs",
                keyColumn: "administrateurid",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "blazorgame",
                table: "Utilisateurs",
                keyColumn: "utilisateurId",
                keyValue: 40);
        }
    }
}
