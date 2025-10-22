using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFC04.Lib.Migrations
{
    /// <inheritdoc />
    public partial class SingleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "single");

            migrationBuilder.CreateTable(
                name: "KundeDetails",
                schema: "single",
                columns: table => new
                {
                    KundeDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefon = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    KundeId = table.Column<int>(type: "int", nullable: false),
                    AdresseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KundeDetails", x => x.KundeDetailsId);
                    table.UniqueConstraint("AK_KundeDetails_KundeId", x => x.KundeId);
                });

            migrationBuilder.CreateTable(
                name: "Adresse",
                schema: "single",
                columns: table => new
                {
                    AdresseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Land = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Plz = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Strasse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Hausnummer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    KundeDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.AdresseId);
                    table.ForeignKey(
                        name: "FK_Adresse_KundeDetails_KundeDetailsId",
                        column: x => x.KundeDetailsId,
                        principalSchema: "single",
                        principalTable: "KundeDetails",
                        principalColumn: "KundeDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kunde",
                schema: "single",
                columns: table => new
                {
                    KundeId = table.Column<int>(type: "int", nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Geschlecht = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    Geburtsdatum = table.Column<DateOnly>(type: "date", precision: 0, nullable: true),
                    Kundeseit = table.Column<DateOnly>(type: "date", precision: 0, nullable: true),
                    KundeDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunde", x => x.KundeId);
                    table.ForeignKey(
                        name: "FK_Kunde_KundeDetails_KundeId",
                        column: x => x.KundeId,
                        principalSchema: "single",
                        principalTable: "KundeDetails",
                        principalColumn: "KundeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresse_KundeDetailsId",
                schema: "single",
                table: "Adresse",
                column: "KundeDetailsId",
                unique: true,
                filter: "[KundeDetailsId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresse",
                schema: "single");

            migrationBuilder.DropTable(
                name: "Kunde",
                schema: "single");

            migrationBuilder.DropTable(
                name: "KundeDetails",
                schema: "single");
        }
    }
}
