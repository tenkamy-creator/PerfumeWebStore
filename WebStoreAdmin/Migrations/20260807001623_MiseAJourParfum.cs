using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStoreAdmin.Migrations
{
    /// <inheritdoc />
    public partial class MiseAJourParfum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteOlfactive_Parfums_ParfumId",
                schema: "dbo",
                table: "NoteOlfactive");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteOlfactive_Parfums_ParfumId1",
                schema: "dbo",
                table: "NoteOlfactive");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteOlfactive_Parfums_ParfumId2",
                schema: "dbo",
                table: "NoteOlfactive");

            migrationBuilder.DropIndex(
                name: "IX_NoteOlfactive_ParfumId",
                schema: "dbo",
                table: "NoteOlfactive");

            migrationBuilder.DropIndex(
                name: "IX_NoteOlfactive_ParfumId1",
                schema: "dbo",
                table: "NoteOlfactive");

            migrationBuilder.DropIndex(
                name: "IX_NoteOlfactive_ParfumId2",
                schema: "dbo",
                table: "NoteOlfactive");

            migrationBuilder.DropColumn(
                name: "ParfumId",
                schema: "dbo",
                table: "NoteOlfactive");

            migrationBuilder.DropColumn(
                name: "ParfumId1",
                schema: "dbo",
                table: "NoteOlfactive");

            migrationBuilder.DropColumn(
                name: "ParfumId2",
                schema: "dbo",
                table: "NoteOlfactive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParfumId",
                schema: "dbo",
                table: "NoteOlfactive",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParfumId1",
                schema: "dbo",
                table: "NoteOlfactive",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParfumId2",
                schema: "dbo",
                table: "NoteOlfactive",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[] { null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_NoteOlfactive_ParfumId",
                schema: "dbo",
                table: "NoteOlfactive",
                column: "ParfumId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteOlfactive_ParfumId1",
                schema: "dbo",
                table: "NoteOlfactive",
                column: "ParfumId1");

            migrationBuilder.CreateIndex(
                name: "IX_NoteOlfactive_ParfumId2",
                schema: "dbo",
                table: "NoteOlfactive",
                column: "ParfumId2");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteOlfactive_Parfums_ParfumId",
                schema: "dbo",
                table: "NoteOlfactive",
                column: "ParfumId",
                principalTable: "Parfums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteOlfactive_Parfums_ParfumId1",
                schema: "dbo",
                table: "NoteOlfactive",
                column: "ParfumId1",
                principalTable: "Parfums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteOlfactive_Parfums_ParfumId2",
                schema: "dbo",
                table: "NoteOlfactive",
                column: "ParfumId2",
                principalTable: "Parfums",
                principalColumn: "Id");
        }
    }
}
