using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFC04.Lib.Migrations.EFC04_OwnedDB
{
    /// <inheritdoc />
    public partial class OwnedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "owned");

            migrationBuilder.CreateTable(
                name: "Adresse",
                schema: "owned",
                columns: table => new
                {
                    AdresseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Land = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Plz = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Strasse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Hausnummer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    KundeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.AdresseId);
                });

            migrationBuilder.CreateTable(
                name: "Kunde",
                schema: "owned",
                columns: table => new
                {
                    KundeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nachname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Geschlecht = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    Geburtsdatum = table.Column<DateOnly>(type: "date", precision: 0, nullable: true),
                    Kundeseit = table.Column<DateOnly>(type: "date", precision: 0, nullable: true),
                    Kundedetails_Telefon = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Kundedetails_Email = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Kundedetails_AnschriftAdresseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunde", x => x.KundeId);
                    table.ForeignKey(
                        name: "FK_Kunde_Adresse_Kundedetails_AnschriftAdresseId",
                        column: x => x.Kundedetails_AnschriftAdresseId,
                        principalSchema: "owned",
                        principalTable: "Adresse",
                        principalColumn: "AdresseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresse_KundeId",
                schema: "owned",
                table: "Adresse",
                column: "KundeId");

            migrationBuilder.CreateIndex(
                name: "IX_Kunde_Kundedetails_AnschriftAdresseId",
                schema: "owned",
                table: "Kunde",
                column: "Kundedetails_AnschriftAdresseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresse_Kunde_KundeId",
                schema: "owned",
                table: "Adresse",
                column: "KundeId",
                principalSchema: "owned",
                principalTable: "Kunde",
                principalColumn: "KundeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresse_Kunde_KundeId",
                schema: "owned",
                table: "Adresse");

            migrationBuilder.DropTable(
                name: "Kunde",
                schema: "owned");

            migrationBuilder.DropTable(
                name: "Adresse",
                schema: "owned");
        }
    }
}
