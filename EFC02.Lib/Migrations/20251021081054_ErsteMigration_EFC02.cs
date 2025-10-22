using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFC02.Lib.Migrations
{
    /// <inheritdoc />
    public partial class ErsteMigration_EFC02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "abteilung",
                schema: "dbo",
                columns: table => new
                {
                    AbteilungId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abteilungsbezeichnung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abteilung", x => x.AbteilungId);
                });

            migrationBuilder.CreateTable(
                name: "funktion",
                schema: "dbo",
                columns: table => new
                {
                    FunktionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Funktionsbezeichnung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funktion", x => x.FunktionId);
                });

            migrationBuilder.CreateTable(
                name: "niederlassung",
                schema: "dbo",
                columns: table => new
                {
                    NiederlassungId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Niederlassungsbezeichnung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Niederlassungsvorwahl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AngelegtAm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeaendertAm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AngelegtVon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GeaendertVon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IstAktiv = table.Column<bool>(type: "bit", nullable: false),
                    IstGeloescht = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_niederlassung", x => x.NiederlassungId);
                });

            migrationBuilder.CreateTable(
                name: "mitarbeiter",
                schema: "dbo",
                columns: table => new
                {
                    MitarbeiterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prsnr = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Geschlecht = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    DatumEintritt = table.Column<DateOnly>(type: "date", nullable: false),
                    DatumAustritt = table.Column<DateOnly>(type: "date", nullable: true),
                    Extern = table.Column<bool>(type: "bit", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Durchwahl = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    AbteilungId = table.Column<int>(type: "int", nullable: true),
                    FunktionId = table.Column<int>(type: "int", nullable: true),
                    Geburtsdatum = table.Column<DateOnly>(type: "date", nullable: true),
                    NiederlassungId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mitarbeiter", x => x.MitarbeiterId);
                    table.ForeignKey(
                        name: "FK_mitarbeiter_abteilung_AbteilungId",
                        column: x => x.AbteilungId,
                        principalSchema: "dbo",
                        principalTable: "abteilung",
                        principalColumn: "AbteilungId");
                    table.ForeignKey(
                        name: "FK_mitarbeiter_funktion_FunktionId",
                        column: x => x.FunktionId,
                        principalSchema: "dbo",
                        principalTable: "funktion",
                        principalColumn: "FunktionId");
                    table.ForeignKey(
                        name: "FK_mitarbeiter_niederlassung_NiederlassungId",
                        column: x => x.NiederlassungId,
                        principalSchema: "dbo",
                        principalTable: "niederlassung",
                        principalColumn: "NiederlassungId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_abteilung_Abteilungsbezeichnung",
                schema: "dbo",
                table: "abteilung",
                column: "Abteilungsbezeichnung",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_funktion_Funktionsbezeichnung",
                schema: "dbo",
                table: "funktion",
                column: "Funktionsbezeichnung",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mitarbeiter_AbteilungId",
                schema: "dbo",
                table: "mitarbeiter",
                column: "AbteilungId");

            migrationBuilder.CreateIndex(
                name: "IX_mitarbeiter_FunktionId",
                schema: "dbo",
                table: "mitarbeiter",
                column: "FunktionId");

            migrationBuilder.CreateIndex(
                name: "IX_mitarbeiter_NiederlassungId",
                schema: "dbo",
                table: "mitarbeiter",
                column: "NiederlassungId");

            migrationBuilder.CreateIndex(
                name: "IX_mitarbeiter_Prsnr",
                schema: "dbo",
                table: "mitarbeiter",
                column: "Prsnr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_niederlassung_Niederlassungsbezeichnung",
                schema: "dbo",
                table: "niederlassung",
                column: "Niederlassungsbezeichnung",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mitarbeiter",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "abteilung",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "funktion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "niederlassung",
                schema: "dbo");
        }
    }
}
