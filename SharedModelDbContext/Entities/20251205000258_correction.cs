using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharedModelDbContext.Entities
{
    /// <inheritdoc />
    public partial class correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 7,
                column: "lienImage",
                value: "mechant_qui_veut_tuer_la_gentille.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "blazorgame",
                table: "Monstres",
                keyColumn: "monstreid",
                keyValue: 7,
                column: "lienImage",
                value: "mechant_qui_veut_tuer_la_gentille.jpg");
        }
    }
}
