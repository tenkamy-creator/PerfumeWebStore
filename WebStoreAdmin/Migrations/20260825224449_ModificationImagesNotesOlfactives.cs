using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStoreAdmin.Migrations
{
    /// <inheritdoc />
    public partial class ModificationImagesNotesOlfactives : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                schema: "dbo",
                table: "NoteOlfactive",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                schema: "dbo",
                table: "NoteOlfactive",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/Images/FamillesOlfactives/Agrumes.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/Images/FamillesOlfactives/Fruitée.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/Images/FamillesOlfactives/Florale.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/Images/FamillesOlfactives/Épicée.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/Images/FamillesOlfactives/Aromatique.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/Images/FamillesOlfactives/Boisée.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/Images/FamillesOlfactives/Orientale.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "/Images/FamillesOlfactives/Gourmande.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "/Images/FamillesOlfactives/Fixateur synthétique.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/Images/FamillesOlfactives/Aquatique.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "/Images/FamillesOlfactives/Verte.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "/Images/FamillesOlfactives/Cuirée.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "/Images/FamillesOlfactives/Fougère.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "/Images/FamillesOlfactives/Chyprée.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                schema: "dbo",
                table: "NoteOlfactive",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                schema: "dbo",
                table: "NoteOlfactive",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FamilleOlfactive",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: null);
        }
    }
}
