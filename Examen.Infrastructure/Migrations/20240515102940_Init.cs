using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Electeurs",
                columns: table => new
                {
                    ElecteurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CIN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonBureauVote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MonGenre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electeurs", x => x.ElecteurId);
                });

            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    DateElection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonTypeElection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elections", x => x.DateElection);
                });

            migrationBuilder.CreateTable(
                name: "PartiePolitiques",
                columns: table => new
                {
                    PartiePolitiqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFondation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartiePolitiques", x => x.PartiePolitiqueId);
                });

            migrationBuilder.CreateTable(
                name: "ParticipationElection",
                columns: table => new
                {
                    ElecteursElecteurId = table.Column<int>(type: "int", nullable: false),
                    ElectionsDateElection = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipationElection", x => new { x.ElecteursElecteurId, x.ElectionsDateElection });
                    table.ForeignKey(
                        name: "FK_ParticipationElection_Electeurs_ElecteursElecteurId",
                        column: x => x.ElecteursElecteurId,
                        principalTable: "Electeurs",
                        principalColumn: "ElecteurId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipationElection_Elections_ElectionsDateElection",
                        column: x => x.ElectionsDateElection,
                        principalTable: "Elections",
                        principalColumn: "DateElection",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    DateElection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartiePolitiqueId = table.Column<int>(type: "int", nullable: false),
                    VoteId = table.Column<int>(type: "int", nullable: false),
                    DateVote = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonBureauVote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => new { x.DateElection, x.PartiePolitiqueId, x.VoteId });
                    table.ForeignKey(
                        name: "FK_Votes_Elections_DateElection",
                        column: x => x.DateElection,
                        principalTable: "Elections",
                        principalColumn: "DateElection",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votes_PartiePolitiques_PartiePolitiqueId",
                        column: x => x.PartiePolitiqueId,
                        principalTable: "PartiePolitiques",
                        principalColumn: "PartiePolitiqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipationElection_ElectionsDateElection",
                table: "ParticipationElection",
                column: "ElectionsDateElection");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_PartiePolitiqueId",
                table: "Votes",
                column: "PartiePolitiqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipationElection");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Electeurs");

            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.DropTable(
                name: "PartiePolitiques");
        }
    }
}
