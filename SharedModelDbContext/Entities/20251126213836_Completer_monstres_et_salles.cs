using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharedModelDbContext.Entities
{
    /// <inheritdoc />
    public partial class Completer_monstres_et_salles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "scoreInitial",
                schema: "blazorgame",
                table: "SallesEnumerable");

            migrationBuilder.AddColumn<double>(
                name: "scoreBonus",
                schema: "blazorgame",
                table: "SallesEnumerable",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "chanceToucher",
                schema: "blazorgame",
                table: "Monstres",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "pointDeVie",
                schema: "blazorgame",
                table: "Monstres",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "pointGagner",
                schema: "blazorgame",
                table: "Monstres",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "scoreBonus",
                schema: "blazorgame",
                table: "SallesEnumerable");

            migrationBuilder.DropColumn(
                name: "chanceToucher",
                schema: "blazorgame",
                table: "Monstres");

            migrationBuilder.DropColumn(
                name: "pointDeVie",
                schema: "blazorgame",
                table: "Monstres");

            migrationBuilder.DropColumn(
                name: "pointGagner",
                schema: "blazorgame",
                table: "Monstres");

            migrationBuilder.AddColumn<int>(
                name: "scoreInitial",
                schema: "blazorgame",
                table: "SallesEnumerable",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
