using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    public partial class BureauVote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MonBureauVote",
                table: "Votes",
                newName: "MonBureauVote_Ville");

            migrationBuilder.RenameColumn(
                name: "MonBureauVote",
                table: "Electeurs",
                newName: "MonBureauVote_Ville");

            migrationBuilder.AddColumn<string>(
                name: "MonBureauVote_Ecole",
                table: "Votes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MonBureauVote_Gouvernorat",
                table: "Votes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MonBureauVote_NumSalle",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MonBureauVote_Ecole",
                table: "Electeurs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MonBureauVote_Gouvernorat",
                table: "Electeurs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MonBureauVote_NumSalle",
                table: "Electeurs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonBureauVote_Ecole",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "MonBureauVote_Gouvernorat",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "MonBureauVote_NumSalle",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "MonBureauVote_Ecole",
                table: "Electeurs");

            migrationBuilder.DropColumn(
                name: "MonBureauVote_Gouvernorat",
                table: "Electeurs");

            migrationBuilder.DropColumn(
                name: "MonBureauVote_NumSalle",
                table: "Electeurs");

            migrationBuilder.RenameColumn(
                name: "MonBureauVote_Ville",
                table: "Votes",
                newName: "MonBureauVote");

            migrationBuilder.RenameColumn(
                name: "MonBureauVote_Ville",
                table: "Electeurs",
                newName: "MonBureauVote");
        }
    }
}
