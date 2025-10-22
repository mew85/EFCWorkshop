using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFC01.Lib.Migrations
{
    /// <inheritdoc />
    public partial class ErsteMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbteilungListe",
                columns: table => new
                {
                    AbteilungId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abteilungsbezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbteilungListe", x => x.AbteilungId);
                });

            migrationBuilder.CreateTable(
                name: "FunktionListe",
                columns: table => new
                {
                    FunktionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Funktionsbezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunktionListe", x => x.FunktionId);
                });

            migrationBuilder.CreateTable(
                name: "NiederlassungListe",
                columns: table => new
                {
                    NiederlassungId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Niederlassungsbezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Niederlassungsvorwahl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiederlassungListe", x => x.NiederlassungId);
                });

            migrationBuilder.CreateTable(
                name: "MitarbeiterListe",
                columns: table => new
                {
                    MitarbeiterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prsnr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geschlecht = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datumeintritt = table.Column<DateOnly>(type: "date", nullable: false),
                    Datumaustritt = table.Column<DateOnly>(type: "date", nullable: true),
                    Extern = table.Column<bool>(type: "bit", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durchwahl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbteilungId = table.Column<int>(type: "int", nullable: true),
                    FunktionId = table.Column<int>(type: "int", nullable: true),
                    Geburtsdatum = table.Column<DateOnly>(type: "date", nullable: true),
                    NiederlassungId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MitarbeiterListe", x => x.MitarbeiterId);
                    table.ForeignKey(
                        name: "FK_MitarbeiterListe_AbteilungListe_AbteilungId",
                        column: x => x.AbteilungId,
                        principalTable: "AbteilungListe",
                        principalColumn: "AbteilungId");
                    table.ForeignKey(
                        name: "FK_MitarbeiterListe_FunktionListe_FunktionId",
                        column: x => x.FunktionId,
                        principalTable: "FunktionListe",
                        principalColumn: "FunktionId");
                    table.ForeignKey(
                        name: "FK_MitarbeiterListe_NiederlassungListe_NiederlassungId",
                        column: x => x.NiederlassungId,
                        principalTable: "NiederlassungListe",
                        principalColumn: "NiederlassungId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MitarbeiterListe_AbteilungId",
                table: "MitarbeiterListe",
                column: "AbteilungId");

            migrationBuilder.CreateIndex(
                name: "IX_MitarbeiterListe_FunktionId",
                table: "MitarbeiterListe",
                column: "FunktionId");

            migrationBuilder.CreateIndex(
                name: "IX_MitarbeiterListe_NiederlassungId",
                table: "MitarbeiterListe",
                column: "NiederlassungId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MitarbeiterListe");

            migrationBuilder.DropTable(
                name: "AbteilungListe");

            migrationBuilder.DropTable(
                name: "FunktionListe");

            migrationBuilder.DropTable(
                name: "NiederlassungListe");
        }
    }
}
