using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebStoreAdmin.Migrations
{
    /// <inheritdoc />
    public partial class AjoutFamillesOlfactives : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotesOlfactives_Parfums_ParfumId",
                table: "NotesOlfactives");

            migrationBuilder.DropForeignKey(
                name: "FK_NotesOlfactives_Parfums_ParfumId1",
                table: "NotesOlfactives");

            migrationBuilder.DropForeignKey(
                name: "FK_NotesOlfactives_Parfums_ParfumId2",
                table: "NotesOlfactives");

            migrationBuilder.DropForeignKey(
                name: "FK_ParfumNotes_NotesOlfactives_NoteOlfactiveId",
                table: "ParfumNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotesOlfactives",
                table: "NotesOlfactives");

            migrationBuilder.RenameTable(
                name: "NotesOlfactives",
                newName: "NoteOlfactive",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_NotesOlfactives_ParfumId2",
                schema: "dbo",
                table: "NoteOlfactive",
                newName: "IX_NoteOlfactive_ParfumId2");

            migrationBuilder.RenameIndex(
                name: "IX_NotesOlfactives_ParfumId1",
                schema: "dbo",
                table: "NoteOlfactive",
                newName: "IX_NoteOlfactive_ParfumId1");

            migrationBuilder.RenameIndex(
                name: "IX_NotesOlfactives_ParfumId",
                schema: "dbo",
                table: "NoteOlfactive",
                newName: "IX_NoteOlfactive_ParfumId");

            migrationBuilder.AddColumn<int>(
                name: "FamilleOlfactiveId",
                schema: "dbo",
                table: "NoteOlfactive",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteOlfactive",
                schema: "dbo",
                table: "NoteOlfactive",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FamilleOlfactive",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilleOlfactive", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FamilleOlfactive",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Agrumes" },
                    { 2, "Fruitée" },
                    { 3, "Florale" },
                    { 4, "Épicée" },
                    { 5, "Aromatique" },
                    { 6, "Boisée" },
                    { 7, "Orientale" },
                    { 8, "Gourmande" },
                    { 9, "Fixateur synthétique" },
                    { 10, "Aquatique" },
                    { 11, "Verte" },
                    { 12, "Cuirée" },
                    { 13, "Fougère" },
                    { 14, "Chyprée" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "NoteOlfactive",
                columns: new[] { "Id", "FamilleOlfactiveId", "Nom", "ParfumId", "ParfumId1", "ParfumId2" },
                values: new object[,]
                {
                    { 1, null, "Bergamote", null, null, null },
                    { 2, null, "Citron", null, null, null },
                    { 3, null, "Citron vert", null, null, null },
                    { 4, null, "Mandarine", null, null, null },
                    { 5, null, "Mandarine verte", null, null, null },
                    { 6, null, "Orange", null, null, null },
                    { 7, null, "Orange sanguine", null, null, null },
                    { 8, null, "Pamplemousse", null, null, null },
                    { 9, null, "Yuzu", null, null, null },
                    { 10, null, "Combava", null, null, null },
                    { 11, null, "Néroli", null, null, null },
                    { 12, null, "Petit grain", null, null, null },
                    { 13, null, "Pomme", null, null, null },
                    { 14, null, "Pomme verte", null, null, null },
                    { 15, null, "Poire", null, null, null },
                    { 16, null, "Pêche", null, null, null },
                    { 17, null, "Abricot", null, null, null },
                    { 18, null, "Prune", null, null, null },
                    { 19, null, "Cerise", null, null, null },
                    { 20, null, "Fraise", null, null, null },
                    { 21, null, "Framboise", null, null, null },
                    { 22, null, "Mûre", null, null, null },
                    { 23, null, "Cassis", null, null, null },
                    { 24, null, "Groseille", null, null, null },
                    { 25, null, "Litchi", null, null, null },
                    { 26, null, "Ananas", null, null, null },
                    { 27, null, "Mangue", null, null, null },
                    { 28, null, "Fruit de la passion", null, null, null },
                    { 29, null, "Melon", null, null, null },
                    { 30, null, "Pastèque", null, null, null },
                    { 31, null, "Noix de coco", null, null, null },
                    { 32, null, "Banane", null, null, null },
                    { 33, null, "Figue", null, null, null },
                    { 34, null, "Datte", null, null, null },
                    { 35, null, "Rose", null, null, null },
                    { 36, null, "Rose bulgare", null, null, null },
                    { 37, null, "Rose de Mai", null, null, null },
                    { 38, null, "Jasmin", null, null, null },
                    { 39, null, "Jasmin sambac", null, null, null },
                    { 40, null, "Tubéreuse", null, null, null },
                    { 41, null, "Ylang-Ylang", null, null, null },
                    { 42, null, "Gardénia", null, null, null },
                    { 43, null, "Fleur d'oranger", null, null, null },
                    { 44, null, "Muguet", null, null, null },
                    { 45, null, "Pivoine", null, null, null },
                    { 46, null, "Magnolia", null, null, null },
                    { 47, null, "Iris", null, null, null },
                    { 48, null, "Violette", null, null, null },
                    { 49, null, "Freesia", null, null, null },
                    { 50, null, "Œillet", null, null, null },
                    { 51, null, "Héliotrope", null, null, null },
                    { 52, null, "Mimosa", null, null, null },
                    { 53, null, "Lilas", null, null, null },
                    { 54, null, "Lotus", null, null, null },
                    { 55, null, "Narcisse", null, null, null },
                    { 56, null, "Poivre noir", null, null, null },
                    { 57, null, "Poivre rose", null, null, null },
                    { 58, null, "Cardamome", null, null, null },
                    { 59, null, "Cannelle", null, null, null },
                    { 60, null, "Safran", null, null, null },
                    { 61, null, "Clou de girofle", null, null, null },
                    { 62, null, "Noix de muscade", null, null, null },
                    { 63, null, "Gingembre", null, null, null },
                    { 64, null, "Baies roses", null, null, null },
                    { 65, null, "Cumin", null, null, null },
                    { 66, null, "Anis étoilé", null, null, null },
                    { 67, null, "Lavande", null, null, null },
                    { 68, null, "Romarin", null, null, null },
                    { 69, null, "Thym", null, null, null },
                    { 70, null, "Sauge", null, null, null },
                    { 71, null, "Menthe", null, null, null },
                    { 72, null, "Basilic", null, null, null },
                    { 73, null, "Estragon", null, null, null },
                    { 74, null, "Absinthe", null, null, null },
                    { 75, null, "Bois de santal", null, null, null },
                    { 76, null, "Cèdre de Virginie", null, null, null },
                    { 77, null, "Cèdre Atlas", null, null, null },
                    { 78, null, "Bois de gaïac", null, null, null },
                    { 79, null, "Vétiver", null, null, null },
                    { 80, null, "Patchouli", null, null, null },
                    { 81, null, "Oud", null, null, null },
                    { 82, null, "Cyprès", null, null, null },
                    { 83, null, "Pin", null, null, null },
                    { 84, null, "Cachemire", null, null, null },
                    { 85, null, "Ambre", null, null, null },
                    { 86, null, "Benjoin", null, null, null },
                    { 87, null, "Encens", null, null, null },
                    { 88, null, "Myrrhe", null, null, null },
                    { 89, null, "Labdanum", null, null, null },
                    { 90, null, "Opoponax", null, null, null },
                    { 91, null, "Baume du Pérou", null, null, null },
                    { 92, null, "Vanille", null, null, null },
                    { 93, null, "Fève Tonka", null, null, null },
                    { 94, null, "Caramel", null, null, null },
                    { 95, null, "Praliné", null, null, null },
                    { 96, null, "Chocolat", null, null, null },
                    { 97, null, "Cacao", null, null, null },
                    { 98, null, "Miel", null, null, null },
                    { 99, null, "Sucre", null, null, null },
                    { 100, null, "Guimauve", null, null, null },
                    { 101, null, "Amande", null, null, null },
                    { 102, null, "Noisette", null, null, null },
                    { 103, null, "Café", null, null, null },
                    { 104, null, "Lait", null, null, null },
                    { 105, null, "Musc blanc", null, null, null },
                    { 106, null, "Ambroxan", null, null, null },
                    { 107, null, "Musc", null, null, null },
                    { 108, null, "Cashmeran", null, null, null },
                    { 109, null, "Iso E Super", null, null, null },
                    { 110, null, "Civette", null, null, null },
                    { 111, null, "Notes marines", null, null, null },
                    { 112, null, "Sel marin", null, null, null },
                    { 113, null, "Algues", null, null, null },
                    { 114, null, "Herbe coupée", null, null, null },
                    { 115, null, "Feuille de violette", null, null, null },
                    { 116, null, "Feuille de tomate", null, null, null },
                    { 117, null, "Thé vert", null, null, null },
                    { 118, null, "Maté", null, null, null },
                    { 119, null, "Cuir", null, null, null },
                    { 120, null, "Tabac", null, null, null },
                    { 121, null, "Fumée", null, null, null },
                    { 122, null, "Whisky", null, null, null },
                    { 123, null, "Rhum", null, null, null },
                    { 124, null, "Cognac", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteOlfactive_FamilleOlfactiveId",
                schema: "dbo",
                table: "NoteOlfactive",
                column: "FamilleOlfactiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteOlfactive_FamilleOlfactive_FamilleOlfactiveId",
                schema: "dbo",
                table: "NoteOlfactive",
                column: "FamilleOlfactiveId",
                principalSchema: "dbo",
                principalTable: "FamilleOlfactive",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ParfumNotes_NoteOlfactive_NoteOlfactiveId",
                table: "ParfumNotes",
                column: "NoteOlfactiveId",
                principalSchema: "dbo",
                principalTable: "NoteOlfactive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteOlfactive_FamilleOlfactive_FamilleOlfactiveId",
                schema: "dbo",
                table: "NoteOlfactive");

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

            migrationBuilder.DropForeignKey(
                name: "FK_ParfumNotes_NoteOlfactive_NoteOlfactiveId",
                table: "ParfumNotes");

            migrationBuilder.DropTable(
                name: "FamilleOlfactive",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteOlfactive",
                schema: "dbo",
                table: "NoteOlfactive");

            migrationBuilder.DropIndex(
                name: "IX_NoteOlfactive_FamilleOlfactiveId",
                schema: "dbo",
                table: "NoteOlfactive");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DropColumn(
                name: "FamilleOlfactiveId",
                schema: "dbo",
                table: "NoteOlfactive");

            migrationBuilder.RenameTable(
                name: "NoteOlfactive",
                schema: "dbo",
                newName: "NotesOlfactives");

            migrationBuilder.RenameIndex(
                name: "IX_NoteOlfactive_ParfumId2",
                table: "NotesOlfactives",
                newName: "IX_NotesOlfactives_ParfumId2");

            migrationBuilder.RenameIndex(
                name: "IX_NoteOlfactive_ParfumId1",
                table: "NotesOlfactives",
                newName: "IX_NotesOlfactives_ParfumId1");

            migrationBuilder.RenameIndex(
                name: "IX_NoteOlfactive_ParfumId",
                table: "NotesOlfactives",
                newName: "IX_NotesOlfactives_ParfumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotesOlfactives",
                table: "NotesOlfactives",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotesOlfactives_Parfums_ParfumId",
                table: "NotesOlfactives",
                column: "ParfumId",
                principalTable: "Parfums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotesOlfactives_Parfums_ParfumId1",
                table: "NotesOlfactives",
                column: "ParfumId1",
                principalTable: "Parfums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotesOlfactives_Parfums_ParfumId2",
                table: "NotesOlfactives",
                column: "ParfumId2",
                principalTable: "Parfums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParfumNotes_NotesOlfactives_NoteOlfactiveId",
                table: "ParfumNotes",
                column: "NoteOlfactiveId",
                principalTable: "NotesOlfactives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
