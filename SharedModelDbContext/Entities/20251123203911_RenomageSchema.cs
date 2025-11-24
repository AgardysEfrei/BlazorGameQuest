using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SharedModelDbContext.Entities
{
    /// <inheritdoc />
    public partial class RenomageSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "blazorgame");

            migrationBuilder.RenameTable(
                name: "Utilisateurs",
                newName: "Utilisateurs",
                newSchema: "blazorgame");

            migrationBuilder.RenameTable(
                name: "ScoreParties",
                newName: "ScoreParties",
                newSchema: "blazorgame");

            migrationBuilder.RenameTable(
                name: "SallesEnumerable",
                newName: "SallesEnumerable",
                newSchema: "blazorgame");

            migrationBuilder.RenameTable(
                name: "Monstres",
                newName: "Monstres",
                newSchema: "blazorgame");

            migrationBuilder.RenameTable(
                name: "Joueurs",
                newName: "Joueurs",
                newSchema: "blazorgame");

            migrationBuilder.RenameTable(
                name: "DonjonsSalles",
                newName: "DonjonsSalles",
                newSchema: "blazorgame");

            migrationBuilder.RenameTable(
                name: "DonjonsEnumerable",
                newName: "DonjonsEnumerable",
                newSchema: "blazorgame");

            migrationBuilder.RenameTable(
                name: "Administrateurs",
                newName: "Administrateurs",
                newSchema: "blazorgame");

            migrationBuilder.AlterColumn<string>(
                name: "prenom",
                schema: "blazorgame",
                table: "Utilisateurs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "nom",
                schema: "blazorgame",
                table: "Utilisateurs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "motDePasse",
                schema: "blazorgame",
                table: "Utilisateurs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "adresseMail",
                schema: "blazorgame",
                table: "Utilisateurs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "utilisateurId",
                schema: "blazorgame",
                table: "Utilisateurs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "score",
                schema: "blazorgame",
                table: "ScoreParties",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "joueurId",
                schema: "blazorgame",
                table: "ScoreParties",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "salleId",
                schema: "blazorgame",
                table: "SallesEnumerable",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "salleid",
                schema: "blazorgame",
                table: "Monstres",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "monstreid",
                schema: "blazorgame",
                table: "Monstres",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "utilisateurId",
                schema: "blazorgame",
                table: "Joueurs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "joueurid",
                schema: "blazorgame",
                table: "Joueurs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "sallesListsalleId",
                schema: "blazorgame",
                table: "DonjonsSalles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "donjonsListdonjonsid",
                schema: "blazorgame",
                table: "DonjonsSalles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "donjonsid",
                schema: "blazorgame",
                table: "DonjonsEnumerable",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "utilisateurId",
                schema: "blazorgame",
                table: "Administrateurs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "administrateurid",
                schema: "blazorgame",
                table: "Administrateurs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Utilisateurs",
                schema: "blazorgame",
                newName: "Utilisateurs");

            migrationBuilder.RenameTable(
                name: "ScoreParties",
                schema: "blazorgame",
                newName: "ScoreParties");

            migrationBuilder.RenameTable(
                name: "SallesEnumerable",
                schema: "blazorgame",
                newName: "SallesEnumerable");

            migrationBuilder.RenameTable(
                name: "Monstres",
                schema: "blazorgame",
                newName: "Monstres");

            migrationBuilder.RenameTable(
                name: "Joueurs",
                schema: "blazorgame",
                newName: "Joueurs");

            migrationBuilder.RenameTable(
                name: "DonjonsSalles",
                schema: "blazorgame",
                newName: "DonjonsSalles");

            migrationBuilder.RenameTable(
                name: "DonjonsEnumerable",
                schema: "blazorgame",
                newName: "DonjonsEnumerable");

            migrationBuilder.RenameTable(
                name: "Administrateurs",
                schema: "blazorgame",
                newName: "Administrateurs");

            migrationBuilder.AlterColumn<string>(
                name: "prenom",
                table: "Utilisateurs",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "nom",
                table: "Utilisateurs",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "motDePasse",
                table: "Utilisateurs",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "adresseMail",
                table: "Utilisateurs",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "utilisateurId",
                table: "Utilisateurs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "score",
                table: "ScoreParties",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "joueurId",
                table: "ScoreParties",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "salleId",
                table: "SallesEnumerable",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "salleid",
                table: "Monstres",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "monstreid",
                table: "Monstres",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "utilisateurId",
                table: "Joueurs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "joueurid",
                table: "Joueurs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "sallesListsalleId",
                table: "DonjonsSalles",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "donjonsListdonjonsid",
                table: "DonjonsSalles",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "donjonsid",
                table: "DonjonsEnumerable",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "utilisateurId",
                table: "Administrateurs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "administrateurid",
                table: "Administrateurs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
