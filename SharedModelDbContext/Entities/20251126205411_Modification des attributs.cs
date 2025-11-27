using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SharedModelDbContext.Entities
{
    /// <inheritdoc />
    public partial class Modificationdesattributs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ScoreParties",
                schema: "blazorgame",
                table: "ScoreParties");

            migrationBuilder.AddColumn<int>(
                name: "ScorePartieId",
                schema: "blazorgame",
                table: "ScoreParties",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "partieTerminee",
                schema: "blazorgame",
                table: "ScoreParties",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "pointsDeVie",
                schema: "blazorgame",
                table: "ScoreParties",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "progression",
                schema: "blazorgame",
                table: "ScoreParties",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "scoreInitial",
                schema: "blazorgame",
                table: "SallesEnumerable",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "lienImage",
                schema: "blazorgame",
                table: "Monstres",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "scorePartieid",
                schema: "blazorgame",
                table: "DonjonsEnumerable",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScoreParties",
                schema: "blazorgame",
                table: "ScoreParties",
                column: "ScorePartieId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreParties_joueurId",
                schema: "blazorgame",
                table: "ScoreParties",
                column: "joueurId");

            migrationBuilder.CreateIndex(
                name: "IX_DonjonsEnumerable_scorePartieid",
                schema: "blazorgame",
                table: "DonjonsEnumerable",
                column: "scorePartieid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DonjonsEnumerable_ScoreParties_scorePartieid",
                schema: "blazorgame",
                table: "DonjonsEnumerable",
                column: "scorePartieid",
                principalSchema: "blazorgame",
                principalTable: "ScoreParties",
                principalColumn: "ScorePartieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonjonsEnumerable_ScoreParties_scorePartieid",
                schema: "blazorgame",
                table: "DonjonsEnumerable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScoreParties",
                schema: "blazorgame",
                table: "ScoreParties");

            migrationBuilder.DropIndex(
                name: "IX_ScoreParties_joueurId",
                schema: "blazorgame",
                table: "ScoreParties");

            migrationBuilder.DropIndex(
                name: "IX_DonjonsEnumerable_scorePartieid",
                schema: "blazorgame",
                table: "DonjonsEnumerable");

            migrationBuilder.DropColumn(
                name: "ScorePartieId",
                schema: "blazorgame",
                table: "ScoreParties");

            migrationBuilder.DropColumn(
                name: "partieTerminee",
                schema: "blazorgame",
                table: "ScoreParties");

            migrationBuilder.DropColumn(
                name: "pointsDeVie",
                schema: "blazorgame",
                table: "ScoreParties");

            migrationBuilder.DropColumn(
                name: "progression",
                schema: "blazorgame",
                table: "ScoreParties");

            migrationBuilder.DropColumn(
                name: "scoreInitial",
                schema: "blazorgame",
                table: "SallesEnumerable");

            migrationBuilder.DropColumn(
                name: "lienImage",
                schema: "blazorgame",
                table: "Monstres");

            migrationBuilder.DropColumn(
                name: "scorePartieid",
                schema: "blazorgame",
                table: "DonjonsEnumerable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScoreParties",
                schema: "blazorgame",
                table: "ScoreParties",
                column: "joueurId");
        }
    }
}
