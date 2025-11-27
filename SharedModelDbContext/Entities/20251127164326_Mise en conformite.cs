using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SharedModelDbContext.Entities
{
    /// <inheritdoc />
    public partial class Miseenconformite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreParties_Joueurs_joueurId",
                schema: "blazorgame",
                table: "ScoreParties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScoreParties",
                schema: "blazorgame",
                table: "ScoreParties");

            migrationBuilder.RenameColumn(
                name: "joueurId",
                schema: "blazorgame",
                table: "ScoreParties",
                newName: "joueurid");

            migrationBuilder.AddColumn<int>(
                name: "joueurId",
                schema: "blazorgame",
                table: "ScoreParties",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScoreParties",
                schema: "blazorgame",
                table: "ScoreParties",
                column: "joueurId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreParties_joueurid",
                schema: "blazorgame",
                table: "ScoreParties",
                column: "joueurid");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreParties_Joueurs_joueurid",
                schema: "blazorgame",
                table: "ScoreParties",
                column: "joueurid",
                principalSchema: "blazorgame",
                principalTable: "Joueurs",
                principalColumn: "joueurid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreParties_Joueurs_joueurid",
                schema: "blazorgame",
                table: "ScoreParties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScoreParties",
                schema: "blazorgame",
                table: "ScoreParties");

            migrationBuilder.DropIndex(
                name: "IX_ScoreParties_joueurid",
                schema: "blazorgame",
                table: "ScoreParties");

            migrationBuilder.DropColumn(
                name: "joueurId",
                schema: "blazorgame",
                table: "ScoreParties");

            migrationBuilder.RenameColumn(
                name: "joueurid",
                schema: "blazorgame",
                table: "ScoreParties",
                newName: "joueurId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScoreParties",
                schema: "blazorgame",
                table: "ScoreParties",
                column: "joueurId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreParties_Joueurs_joueurId",
                schema: "blazorgame",
                table: "ScoreParties",
                column: "joueurId",
                principalSchema: "blazorgame",
                principalTable: "Joueurs",
                principalColumn: "joueurid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
