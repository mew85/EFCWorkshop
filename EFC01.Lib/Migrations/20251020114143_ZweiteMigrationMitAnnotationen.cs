using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFC01.Lib.Migrations
{
    /// <inheritdoc />
    public partial class ZweiteMigrationMitAnnotationen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MitarbeiterListe_AbteilungListe_AbteilungId",
                table: "MitarbeiterListe");

            migrationBuilder.DropForeignKey(
                name: "FK_MitarbeiterListe_FunktionListe_FunktionId",
                table: "MitarbeiterListe");

            migrationBuilder.DropForeignKey(
                name: "FK_MitarbeiterListe_NiederlassungListe_NiederlassungId",
                table: "MitarbeiterListe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NiederlassungListe",
                table: "NiederlassungListe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MitarbeiterListe",
                table: "MitarbeiterListe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FunktionListe",
                table: "FunktionListe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbteilungListe",
                table: "AbteilungListe");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "NiederlassungListe",
                newName: "niederlassung",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "MitarbeiterListe",
                newName: "mitarbeiter",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FunktionListe",
                newName: "funktion",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AbteilungListe",
                newName: "abteilung",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_MitarbeiterListe_NiederlassungId",
                schema: "dbo",
                table: "mitarbeiter",
                newName: "IX_mitarbeiter_NiederlassungId");

            migrationBuilder.RenameIndex(
                name: "IX_MitarbeiterListe_FunktionId",
                schema: "dbo",
                table: "mitarbeiter",
                newName: "IX_mitarbeiter_FunktionId");

            migrationBuilder.RenameIndex(
                name: "IX_MitarbeiterListe_AbteilungId",
                schema: "dbo",
                table: "mitarbeiter",
                newName: "IX_mitarbeiter_AbteilungId");

            migrationBuilder.AlterColumn<string>(
                name: "Niederlassungsvorwahl",
                schema: "dbo",
                table: "niederlassung",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Niederlassungsbezeichnung",
                schema: "dbo",
                table: "niederlassung",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Vorname",
                schema: "dbo",
                table: "mitarbeiter",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Prsnr",
                schema: "dbo",
                table: "mitarbeiter",
                type: "varchar(4)",
                unicode: false,
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "NiederlassungId",
                schema: "dbo",
                table: "mitarbeiter",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nachname",
                schema: "dbo",
                table: "mitarbeiter",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Geschlecht",
                schema: "dbo",
                table: "mitarbeiter",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "mitarbeiter",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Durchwahl",
                schema: "dbo",
                table: "mitarbeiter",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Funktionsbezeichnung",
                schema: "dbo",
                table: "funktion",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Abteilungsbezeichnung",
                schema: "dbo",
                table: "abteilung",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_niederlassung",
                schema: "dbo",
                table: "niederlassung",
                column: "NiederlassungId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mitarbeiter",
                schema: "dbo",
                table: "mitarbeiter",
                column: "MitarbeiterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_funktion",
                schema: "dbo",
                table: "funktion",
                column: "FunktionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_abteilung",
                schema: "dbo",
                table: "abteilung",
                column: "AbteilungId");

            migrationBuilder.CreateIndex(
                name: "IX_niederlassung_Niederlassungsbezeichnung",
                schema: "dbo",
                table: "niederlassung",
                column: "Niederlassungsbezeichnung",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mitarbeiter_Prsnr",
                schema: "dbo",
                table: "mitarbeiter",
                column: "Prsnr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_funktion_Funktionsbezeichnung",
                schema: "dbo",
                table: "funktion",
                column: "Funktionsbezeichnung",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_abteilung_Abteilungsbezeichnung",
                schema: "dbo",
                table: "abteilung",
                column: "Abteilungsbezeichnung",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_mitarbeiter_abteilung_AbteilungId",
                schema: "dbo",
                table: "mitarbeiter",
                column: "AbteilungId",
                principalSchema: "dbo",
                principalTable: "abteilung",
                principalColumn: "AbteilungId");

            migrationBuilder.AddForeignKey(
                name: "FK_mitarbeiter_funktion_FunktionId",
                schema: "dbo",
                table: "mitarbeiter",
                column: "FunktionId",
                principalSchema: "dbo",
                principalTable: "funktion",
                principalColumn: "FunktionId");

            migrationBuilder.AddForeignKey(
                name: "FK_mitarbeiter_niederlassung_NiederlassungId",
                schema: "dbo",
                table: "mitarbeiter",
                column: "NiederlassungId",
                principalSchema: "dbo",
                principalTable: "niederlassung",
                principalColumn: "NiederlassungId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mitarbeiter_abteilung_AbteilungId",
                schema: "dbo",
                table: "mitarbeiter");

            migrationBuilder.DropForeignKey(
                name: "FK_mitarbeiter_funktion_FunktionId",
                schema: "dbo",
                table: "mitarbeiter");

            migrationBuilder.DropForeignKey(
                name: "FK_mitarbeiter_niederlassung_NiederlassungId",
                schema: "dbo",
                table: "mitarbeiter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_niederlassung",
                schema: "dbo",
                table: "niederlassung");

            migrationBuilder.DropIndex(
                name: "IX_niederlassung_Niederlassungsbezeichnung",
                schema: "dbo",
                table: "niederlassung");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mitarbeiter",
                schema: "dbo",
                table: "mitarbeiter");

            migrationBuilder.DropIndex(
                name: "IX_mitarbeiter_Prsnr",
                schema: "dbo",
                table: "mitarbeiter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_funktion",
                schema: "dbo",
                table: "funktion");

            migrationBuilder.DropIndex(
                name: "IX_funktion_Funktionsbezeichnung",
                schema: "dbo",
                table: "funktion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_abteilung",
                schema: "dbo",
                table: "abteilung");

            migrationBuilder.DropIndex(
                name: "IX_abteilung_Abteilungsbezeichnung",
                schema: "dbo",
                table: "abteilung");

            migrationBuilder.RenameTable(
                name: "niederlassung",
                schema: "dbo",
                newName: "NiederlassungListe");

            migrationBuilder.RenameTable(
                name: "mitarbeiter",
                schema: "dbo",
                newName: "MitarbeiterListe");

            migrationBuilder.RenameTable(
                name: "funktion",
                schema: "dbo",
                newName: "FunktionListe");

            migrationBuilder.RenameTable(
                name: "abteilung",
                schema: "dbo",
                newName: "AbteilungListe");

            migrationBuilder.RenameIndex(
                name: "IX_mitarbeiter_NiederlassungId",
                table: "MitarbeiterListe",
                newName: "IX_MitarbeiterListe_NiederlassungId");

            migrationBuilder.RenameIndex(
                name: "IX_mitarbeiter_FunktionId",
                table: "MitarbeiterListe",
                newName: "IX_MitarbeiterListe_FunktionId");

            migrationBuilder.RenameIndex(
                name: "IX_mitarbeiter_AbteilungId",
                table: "MitarbeiterListe",
                newName: "IX_MitarbeiterListe_AbteilungId");

            migrationBuilder.AlterColumn<string>(
                name: "Niederlassungsvorwahl",
                table: "NiederlassungListe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Niederlassungsbezeichnung",
                table: "NiederlassungListe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Vorname",
                table: "MitarbeiterListe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Prsnr",
                table: "MitarbeiterListe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(4)",
                oldUnicode: false,
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<int>(
                name: "NiederlassungId",
                table: "MitarbeiterListe",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nachname",
                table: "MitarbeiterListe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Geschlecht",
                table: "MitarbeiterListe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "MitarbeiterListe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Durchwahl",
                table: "MitarbeiterListe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Funktionsbezeichnung",
                table: "FunktionListe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Abteilungsbezeichnung",
                table: "AbteilungListe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NiederlassungListe",
                table: "NiederlassungListe",
                column: "NiederlassungId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MitarbeiterListe",
                table: "MitarbeiterListe",
                column: "MitarbeiterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FunktionListe",
                table: "FunktionListe",
                column: "FunktionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbteilungListe",
                table: "AbteilungListe",
                column: "AbteilungId");

            migrationBuilder.AddForeignKey(
                name: "FK_MitarbeiterListe_AbteilungListe_AbteilungId",
                table: "MitarbeiterListe",
                column: "AbteilungId",
                principalTable: "AbteilungListe",
                principalColumn: "AbteilungId");

            migrationBuilder.AddForeignKey(
                name: "FK_MitarbeiterListe_FunktionListe_FunktionId",
                table: "MitarbeiterListe",
                column: "FunktionId",
                principalTable: "FunktionListe",
                principalColumn: "FunktionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MitarbeiterListe_NiederlassungListe_NiederlassungId",
                table: "MitarbeiterListe",
                column: "NiederlassungId",
                principalTable: "NiederlassungListe",
                principalColumn: "NiederlassungId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
