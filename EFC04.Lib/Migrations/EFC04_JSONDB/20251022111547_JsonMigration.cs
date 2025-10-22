using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFC04.Lib.Migrations.EFC04_JSONDB
{
    /// <inheritdoc />
    public partial class JsonMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "json");

            migrationBuilder.CreateTable(
                name: "Kunde",
                schema: "json",
                columns: table => new
                {
                    KundeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nachname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Geschlecht = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    Geburtsdatum = table.Column<DateOnly>(type: "date", precision: 0, nullable: true),
                    Kundeseit = table.Column<DateOnly>(type: "date", precision: 0, nullable: true),
                    Kundedetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunde", x => x.KundeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kunde",
                schema: "json");
        }
    }
}
