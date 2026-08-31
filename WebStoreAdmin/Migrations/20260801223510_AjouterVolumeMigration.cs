using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStoreAdmin.Migrations
{
    /// <inheritdoc />
    public partial class AjouterVolumeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Volume",
                table: "Parfums",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Parfums");
        }
    }
}
