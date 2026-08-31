using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStoreAdmin.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImagesParfum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePrincipale = table.Column<bool>(type: "bit", nullable: false),
                    OrdreAffichage = table.Column<int>(type: "int", nullable: false),
                    ParfumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesParfum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagesParfum_Parfums_ParfumId",
                        column: x => x.ParfumId,
                        principalTable: "Parfums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagesParfum_ParfumId",
                table: "ImagesParfum",
                column: "ParfumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagesParfum");
        }
    }
}
