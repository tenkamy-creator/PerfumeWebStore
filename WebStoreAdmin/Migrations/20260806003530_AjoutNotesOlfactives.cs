using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStoreAdmin.Migrations
{
    /// <inheritdoc />
    public partial class AjoutNotesOlfactives : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotesOlfactives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParfumId = table.Column<int>(type: "int", nullable: true),
                    ParfumId1 = table.Column<int>(type: "int", nullable: true),
                    ParfumId2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotesOlfactives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotesOlfactives_Parfums_ParfumId",
                        column: x => x.ParfumId,
                        principalTable: "Parfums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotesOlfactives_Parfums_ParfumId1",
                        column: x => x.ParfumId1,
                        principalTable: "Parfums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotesOlfactives_Parfums_ParfumId2",
                        column: x => x.ParfumId2,
                        principalTable: "Parfums",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParfumNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParfumId = table.Column<int>(type: "int", nullable: false),
                    NoteOlfactiveId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParfumNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParfumNotes_NotesOlfactives_NoteOlfactiveId",
                        column: x => x.NoteOlfactiveId,
                        principalTable: "NotesOlfactives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParfumNotes_Parfums_ParfumId",
                        column: x => x.ParfumId,
                        principalTable: "Parfums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotesOlfactives_ParfumId",
                table: "NotesOlfactives",
                column: "ParfumId");

            migrationBuilder.CreateIndex(
                name: "IX_NotesOlfactives_ParfumId1",
                table: "NotesOlfactives",
                column: "ParfumId1");

            migrationBuilder.CreateIndex(
                name: "IX_NotesOlfactives_ParfumId2",
                table: "NotesOlfactives",
                column: "ParfumId2");

            migrationBuilder.CreateIndex(
                name: "IX_ParfumNotes_NoteOlfactiveId",
                table: "ParfumNotes",
                column: "NoteOlfactiveId");

            migrationBuilder.CreateIndex(
                name: "IX_ParfumNotes_ParfumId",
                table: "ParfumNotes",
                column: "ParfumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParfumNotes");

            migrationBuilder.DropTable(
                name: "NotesOlfactives");
        }
    }
}
