using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFC02.Lib.Migrations
{
    /// <inheritdoc />
    public partial class ZweiteMigration_EFC02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IstGeloescht",
                schema: "dbo",
                table: "niederlassung",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IstAktiv",
                schema: "dbo",
                table: "niederlassung",
                type: "bit",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GeaendertAm",
                schema: "dbo",
                table: "niederlassung",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "AngelegtVon",
                schema: "dbo",
                table: "niederlassung",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValueSql: "suser_sname()",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AngelegtAm",
                schema: "dbo",
                table: "niederlassung",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "abteilung",
                columns: new[] { "AbteilungId", "Abteilungsbezeichnung" },
                values: new object[,]
                {
                    { 1, "Geschäftsleitung/RW" },
                    { 2, "Infrastruktur" },
                    { 3, "Marketing" },
                    { 4, "Produktion" },
                    { 5, "Vertrieb" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "funktion",
                columns: new[] { "FunktionId", "Funktionsbezeichnung" },
                values: new object[,]
                {
                    { 1, "Berater/in" },
                    { 2, "Bereichsleiter/in" },
                    { 3, "Entwickler/in" },
                    { 4, "Freie/r Mitarbeiter/in" },
                    { 5, "Geschäftsführer/in" },
                    { 6, "Mitarbeiter/in" },
                    { 7, "Projektleiter/in" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "niederlassung",
                columns: new[] { "NiederlassungId", "AngelegtAm", "AngelegtVon", "GeaendertAm", "GeaendertVon", "IstAktiv", "IstGeloescht", "Niederlassungsbezeichnung", "Niederlassungsvorwahl" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 11, 11, 45, 0, 0, DateTimeKind.Unspecified), "Teilnehmer", null, null, true, false, "Berlin", "(030) 65756" },
                    { 2, new DateTime(2025, 10, 11, 11, 45, 0, 0, DateTimeKind.Unspecified), "Teilnehmer", null, null, true, false, "Frankfurt", "(060) 345012" },
                    { 3, new DateTime(2025, 10, 11, 11, 45, 0, 0, DateTimeKind.Unspecified), "Teilnehmer", null, null, true, false, "Hamburg", "(040) 1234" },
                    { 4, new DateTime(2025, 10, 11, 11, 45, 0, 0, DateTimeKind.Unspecified), "Teilnehmer", null, null, true, false, "München", "(089) 54398" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mitarbeiter",
                columns: new[] { "MitarbeiterId", "AbteilungId", "DatumAustritt", "DatumEintritt", "Durchwahl", "Email", "Extern", "FunktionId", "Geburtsdatum", "Geschlecht", "Nachname", "NiederlassungId", "Prsnr", "Vorname" },
                values: new object[,]
                {
                    { 1, 1, null, new DateOnly(2006, 1, 1), "20", "gpaul@projektdb.de", false, 5, new DateOnly(1993, 8, 23), "w", "Paul", 3, "1001", "Gabriele" },
                    { 2, 1, null, new DateOnly(2012, 5, 15), "22", "kunterlauf@projektdb.de", false, 6, new DateOnly(1970, 2, 6), "w", "Unterlauf", 3, "1002", "Karin" },
                    { 3, 1, null, new DateOnly(2010, 10, 1), "21", "eschiefner@projektdb.de", false, 6, new DateOnly(1980, 5, 14), "w", "Schiefner", 3, "1003", "Emi" },
                    { 4, 2, null, new DateOnly(2010, 10, 15), "4567", "ogeist@projektdb.de", false, 6, new DateOnly(1979, 5, 13), "m", "Geist", 2, "1004", "Ottmar" },
                    { 5, 2, null, new DateOnly(2006, 1, 2), "123", "hwendisch@projektdb.de", false, 6, new DateOnly(1981, 5, 14), "m", "Wendisch", 1, "1005", "Horst" },
                    { 6, 2, null, new DateOnly(2006, 1, 3), "13", "gkoritz@projektdb.de", false, 5, new DateOnly(1985, 6, 16), "w", "Koritz", 3, "1006", "Gundula" },
                    { 7, 3, null, new DateOnly(2006, 1, 17), "35", "klorenz@projektdb.de", false, 2, new DateOnly(1998, 10, 26), "w", "Lorenz", 3, "1007", "Kathrin" },
                    { 8, 3, null, new DateOnly(2006, 1, 18), "36", "amuehle@projektdb.de", false, 6, new DateOnly(1971, 3, 8), "m", "Mühle", 3, "1008", "Andreas" },
                    { 9, 4, null, new DateOnly(2006, 1, 1), "234", "sarendt@projektdb.de", false, 2, new DateOnly(1986, 7, 18), "w", "Arendt", 1, "1009", "Sibylle" },
                    { 10, 4, null, new DateOnly(2020, 1, 1), "30", "oheinrich@projektdb.de", false, 6, new DateOnly(1979, 5, 13), "m", "Heinrich", 4, "1010", "Otto" },
                    { 11, 4, null, new DateOnly(2006, 1, 1), "12", "hrostig@projektdb.de", false, 6, new DateOnly(1993, 8, 23), "w", "Rostig", null, "1011", "Heidi" },
                    { 12, 4, null, new DateOnly(2006, 1, 4), "", "fgasch@projektdb.de", false, 4, new DateOnly(1979, 3, 15), "m", "Gasch", null, "1012", "Fritz" },
                    { 13, 4, null, new DateOnly(2015, 10, 1), "232", "mschulze@projektdb.de", true, 6, new DateOnly(1969, 2, 6), "m", "Schulze", null, "1013", "Mathias" },
                    { 14, 4, null, new DateOnly(2015, 10, 1), "4566", "boehme@projektdb.de", false, 6, new DateOnly(1996, 9, 24), "m", "Oehme", null, "1014", "Ben" },
                    { 15, 4, null, new DateOnly(2018, 10, 1), "4568", "kvettin@projektdb.de", false, 6, new DateOnly(1969, 2, 5), "m", "Vettin", null, "1015", "Konstantin" },
                    { 16, 4, null, new DateOnly(2018, 1, 13), "20", "akayser@projektdb.de", false, 6, new DateOnly(1968, 2, 5), "m", "Kayser", null, "1016", "Adel" },
                    { 17, 4, null, new DateOnly(2006, 1, 14), "4567", "agorochow@projektdb.de", false, 6, new DateOnly(2002, 11, 28), "m", "Gorochow", null, "1017", "Alexander" },
                    { 18, 4, null, new DateOnly(2006, 1, 15), "40", "joreilley@projektdb.de", false, 6, new DateOnly(2000, 10, 27), "m", "O'Reilly", null, "1018", "John" },
                    { 19, 4, null, new DateOnly(2016, 1, 16), "233", "mkasischke@projektdb.de", false, 6, new DateOnly(2002, 11, 28), "w", "Kasischke", null, "1019", "Mandy" },
                    { 20, 4, null, new DateOnly(2011, 1, 19), "4569", "mozuen@projektdb.de", false, 6, new DateOnly(1981, 5, 14), "m", "Ozün", null, "1020", "Mehmet" },
                    { 21, 4, null, new DateOnly(2006, 1, 20), "50", "sboerner@projektdb.de", false, 6, new DateOnly(1989, 7, 20), "w", "Kaykin", null, "1021", "Zylfiye" },
                    { 22, 4, null, new DateOnly(2006, 1, 21), "4570", "pfuehr@projektdb.de", false, 6, new DateOnly(1989, 7, 20), "m", "Führ", null, "1022", "Paul" },
                    { 23, 4, null, new DateOnly(2006, 1, 22), "4571", "krossberg@projektdb.de", false, 6, new DateOnly(2002, 11, 28), "w", "Roßberg", null, "1023", "Katja" },
                    { 24, 4, null, new DateOnly(2010, 10, 1), "234", "jcernij@projektdb.de", false, 6, new DateOnly(1976, 4, 11), "m", "Cernij", null, "1024", "Juri" },
                    { 25, 4, null, new DateOnly(2022, 10, 1), "4572", "gfeluscini@projektdb.de", false, 6, new DateOnly(2004, 11, 29), "m", "Feluscini", null, "1025", "Giovanni" },
                    { 26, 4, null, new DateOnly(2009, 10, 1), "14", "molzychovski@projektdb.de", false, 6, new DateOnly(1980, 12, 4), "m", "Olzychovski", null, "1026", "Marek" },
                    { 27, 4, null, new DateOnly(2010, 10, 1), "15", "ffleurol@projektdb.de", false, 6, new DateOnly(1995, 9, 23), "m", "Fleurol", null, "1027", "Francois" },
                    { 28, 4, null, new DateOnly(2010, 10, 1), "16", "kpiskun@projektdb.de", false, 6, new DateOnly(1966, 1, 4), "m", "Piskun", null, "1028", "Konstantin" },
                    { 29, 5, null, new DateOnly(2006, 1, 1), "", "heinz@haase.de", true, 4, new DateOnly(2001, 11, 27), "m", "Haase", null, "1029", "Heinz" },
                    { 30, 5, null, new DateOnly(2006, 1, 1), "33", "gthurow@projektdb.de", true, 4, new DateOnly(1991, 8, 21), "m", "Thurow", null, "1030", "Gerald" },
                    { 31, 5, null, new DateOnly(2010, 10, 1), "124", "sfischer@projektdb.de", false, 6, new DateOnly(1979, 5, 13), "w", "Fischer", null, "1031", "Sonja" },
                    { 32, 5, null, new DateOnly(2010, 10, 1), "10", "hschwienke@projektdb.de", false, 6, new DateOnly(1974, 3, 9), "w", "Schwienke", null, "1032", "Hildegard" },
                    { 33, 5, null, new DateOnly(2010, 10, 1), "34", "eoltenbuerstel@projektdb.de", false, 2, new DateOnly(1964, 1, 2), "m", "Oltenbürstel", null, "1033", "Erich" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "funktion",
                keyColumn: "FunktionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "funktion",
                keyColumn: "FunktionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "funktion",
                keyColumn: "FunktionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mitarbeiter",
                keyColumn: "MitarbeiterId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "abteilung",
                keyColumn: "AbteilungId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "abteilung",
                keyColumn: "AbteilungId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "abteilung",
                keyColumn: "AbteilungId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "abteilung",
                keyColumn: "AbteilungId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "abteilung",
                keyColumn: "AbteilungId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "funktion",
                keyColumn: "FunktionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "funktion",
                keyColumn: "FunktionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "funktion",
                keyColumn: "FunktionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "funktion",
                keyColumn: "FunktionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "niederlassung",
                keyColumn: "NiederlassungId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "niederlassung",
                keyColumn: "NiederlassungId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "niederlassung",
                keyColumn: "NiederlassungId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "niederlassung",
                keyColumn: "NiederlassungId",
                keyValue: 4);

            migrationBuilder.AlterColumn<bool>(
                name: "IstGeloescht",
                schema: "dbo",
                table: "niederlassung",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IstAktiv",
                schema: "dbo",
                table: "niederlassung",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GeaendertAm",
                schema: "dbo",
                table: "niederlassung",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AngelegtVon",
                schema: "dbo",
                table: "niederlassung",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValueSql: "suser_sname()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AngelegtAm",
                schema: "dbo",
                table: "niederlassung",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");
        }
    }
}
