using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentraleRecrutement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entreprise",
                columns: table => new
                {
                    IdEntreprise = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChiffreAffaire = table.Column<int>(type: "int", nullable: false),
                    DateFondation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Effectif = table.Column<int>(type: "int", nullable: false),
                    NomEntreprise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Secteur = table.Column<int>(type: "int", nullable: false),
                    AdresseEntreprise_Ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresseEntreprise_Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresseEntreprise_CodePostal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprise", x => x.IdEntreprise);
                });

            migrationBuilder.CreateTable(
                name: "Postulant",
                columns: table => new
                {
                    IdPstulant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postulant", x => x.IdPstulant);
                });

            migrationBuilder.CreateTable(
                name: "Offre",
                columns: table => new
                {
                    IdOffre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePublication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TitreOffre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeContrat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntrepriseFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offre", x => x.IdOffre);
                    table.ForeignKey(
                        name: "FK_Offre_Entreprise_EntrepriseFK",
                        column: x => x.EntrepriseFK,
                        principalTable: "Entreprise",
                        principalColumn: "IdEntreprise",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidature",
                columns: table => new
                {
                    OffresIdOffre = table.Column<int>(type: "int", nullable: false),
                    PostulantsIdPstulant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidature", x => new { x.OffresIdOffre, x.PostulantsIdPstulant });
                    table.ForeignKey(
                        name: "FK_Candidature_Offre_OffresIdOffre",
                        column: x => x.OffresIdOffre,
                        principalTable: "Offre",
                        principalColumn: "IdOffre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidature_Postulant_PostulantsIdPstulant",
                        column: x => x.PostulantsIdPstulant,
                        principalTable: "Postulant",
                        principalColumn: "IdPstulant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidature_PostulantsIdPstulant",
                table: "Candidature",
                column: "PostulantsIdPstulant");

            migrationBuilder.CreateIndex(
                name: "IX_Offre_EntrepriseFK",
                table: "Offre",
                column: "EntrepriseFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidature");

            migrationBuilder.DropTable(
                name: "Offre");

            migrationBuilder.DropTable(
                name: "Postulant");

            migrationBuilder.DropTable(
                name: "Entreprise");
        }
    }
}
