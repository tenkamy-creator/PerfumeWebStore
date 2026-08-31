using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStoreAdmin.Migrations
{
    /// <inheritdoc />
    public partial class AjoutImagesNotesEtFamillesOlfactives : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "dbo",
                table: "NoteOlfactive",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "dbo",
                table: "FamilleOlfactive",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/bergamote.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/citron.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/citronvert.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/mandarine.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/mandarineverte.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/orange.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/orangesanguine.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/pamplemousse.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/yuzu.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/combava.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/neroli.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/petitgrain.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/pomme.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/pommeverte.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/poire.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/peche.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/abricot.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/prune.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cerise.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/fraise.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/framboise.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/mure.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cassis.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/groseille.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 25,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/litchi.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 26,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/ananas.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 27,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/mangue.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 28,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/fruitdelapassion.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 29,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/melon.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 30,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/pasteque.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 31,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/noixdecoco.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 32,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/banane.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 33,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/figue.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 34,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/datte.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 35,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/rose.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 36,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/rosebulgare.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 37,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/rosedemai.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 38,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/jasmin.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 39,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/jasminsambac.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 40,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/tubereuse.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 41,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/ylangylang.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 42,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/gardenia.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 43,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/fleurdoranger.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 44,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/muguet.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 45,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/pivoine.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 46,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/magnolia.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 47,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/iris.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 48,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/violette.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 49,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/freesia.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 50,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/oeillet.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 51,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/heliotrope.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 52,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/mimosa.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 53,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/lilas.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 54,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/lotus.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 55,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/narcisse.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 56,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/poivrenoir.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 57,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/poivrerose.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 58,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cardamome.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 59,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cannelle.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 60,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/safran.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 61,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cloudegirofle.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 62,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/noixdemuscade.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 63,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/gingembre.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 64,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/baiesroses.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 65,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cumin.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 66,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/anisetoile.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 67,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/lavande.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 68,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/romarin.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 69,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/thym.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 70,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/sauge.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 71,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/menthe.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 72,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/basilic.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 73,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/estragon.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 74,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/absinthe.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 75,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/boisdesantal.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 76,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cedredevirginie.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 77,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cedreatlas.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 78,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/boisdegaiac.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 79,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/vetiver.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 80,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/patchouli.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 81,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/oud.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 82,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cypres.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 83,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/pin.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 84,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cachemire.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 85,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/ambre.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 86,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/benjoin.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 87,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/encens.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 88,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/myrrhe.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 89,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/labdanum.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 90,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/opoponax.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 91,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/baumeduperou.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 92,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/vanille.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 93,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/fevetonka.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 94,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/caramel.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 95,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/praline.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 96,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/chocolat.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 97,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cacao.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 98,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/miel.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 99,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/sucre.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 100,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/guimauve.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 101,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/amande.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 102,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/noisette.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 103,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cafe.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 104,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/lait.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 105,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/muscblanc.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 106,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/ambroxan.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 107,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/musc.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 108,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cashmeran.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 109,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/isoesuper.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 110,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/civette.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 111,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/notesmarines.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 112,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/selmarin.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 113,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/algues.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 114,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/herbecoupee.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 115,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/feuilledeviolette.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 116,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/feuilledetomate.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 117,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/thevert.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 118,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/mate.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 119,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cuir.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 120,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/tabac.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 121,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/fumee.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 122,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/whisky.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 123,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/rhum.png");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NoteOlfactive",
                keyColumn: "Id",
                keyValue: 124,
                column: "ImageUrl",
                value: "/Images/NotesOlfactives/cognac.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "dbo",
                table: "NoteOlfactive");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "dbo",
                table: "FamilleOlfactive");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                schema: "dbo",
                table: "NoteOlfactive",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
