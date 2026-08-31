using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.Data
{
    public class NoteOlfactiveConfiguration : IEntityTypeConfiguration<NoteOlfactive>
    {
        public void Configure(EntityTypeBuilder<NoteOlfactive> builder)
        {
            builder.ToTable("NoteOlfactive", schema: "dbo");

            builder.HasKey(c => c.Id);

            builder.HasData(

    // =============================
    // AGRUMES
    // =============================
    new NoteOlfactive { Id = 1, Nom = "Bergamote", ImageUrl = "/Images/NotesOlfactives/Bergamote.png", FamilleOlfactiveId = 1 },
    new NoteOlfactive { Id = 2, Nom = "Citron", ImageUrl = "/Images/NotesOlfactives/Citron.png", FamilleOlfactiveId = 1 },
    new NoteOlfactive { Id = 3, Nom = "Citron vert", ImageUrl = "/Images/NotesOlfactives/Citron vert.png", FamilleOlfactiveId = 1 },
    new NoteOlfactive { Id = 4, Nom = "Mandarine", ImageUrl = "/Images/NotesOlfactives/Mandarine.png", FamilleOlfactiveId = 1 },
    new NoteOlfactive { Id = 5, Nom = "Mandarine verte", ImageUrl = "/Images/NotesOlfactives/Mandarine verte.png", FamilleOlfactiveId = 1 },
    new NoteOlfactive { Id = 6, Nom = "Orange", ImageUrl = "/Images/NotesOlfactives/Orange.png", FamilleOlfactiveId = 1 },
    new NoteOlfactive { Id = 7, Nom = "Orange sanguine", ImageUrl = "/Images/NotesOlfactives/Orange sanguine.png", FamilleOlfactiveId = 1 },
    new NoteOlfactive { Id = 8, Nom = "Pamplemousse", ImageUrl = "/Images/NotesOlfactives/Pamplemousse.png", FamilleOlfactiveId = 1 },
    new NoteOlfactive { Id = 9, Nom = "Yuzu", ImageUrl = "/Images/NotesOlfactives/Yuzu.png", FamilleOlfactiveId = 1 },
    new NoteOlfactive { Id = 10, Nom = "Combava", ImageUrl = "/Images/NotesOlfactives/Combava.png", FamilleOlfactiveId = 1 },
    new NoteOlfactive { Id = 11, Nom = "Néroli", ImageUrl = "/Images/NotesOlfactives/Néroli.png", FamilleOlfactiveId = 1 },
    new NoteOlfactive { Id = 12, Nom = "Petit grain", ImageUrl = "/Images/NotesOlfactives/Petit grain.png", FamilleOlfactiveId = 1 },

    // =============================
    // FRUITS
    // =============================
    new NoteOlfactive { Id = 13, Nom = "Pomme", ImageUrl = "/Images/NotesOlfactives/Pomme.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 14, Nom = "Pomme verte", ImageUrl = "/Images/NotesOlfactives/Pomme verte.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 15, Nom = "Poire", ImageUrl = "/Images/NotesOlfactives/Poire.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 16, Nom = "Pêche", ImageUrl = "/Images/NotesOlfactives/Pêche.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 17, Nom = "Abricot", ImageUrl = "/Images/NotesOlfactives/Abricot.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 18, Nom = "Prune", ImageUrl = "/Images/NotesOlfactives/Prune.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 19, Nom = "Cerise", ImageUrl = "/Images/NotesOlfactives/Cerise.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 20, Nom = "Fraise", ImageUrl = "/Images/NotesOlfactives/Fraise.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 21, Nom = "Framboise", ImageUrl = "/Images/NotesOlfactives/Framboise.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 22, Nom = "Mûre", ImageUrl = "/Images/NotesOlfactives/Mûre.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 23, Nom = "Cassis", ImageUrl = "/Images/NotesOlfactives/Cassis.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 24, Nom = "Groseille", ImageUrl = "/Images/NotesOlfactives/Groseille.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 25, Nom = "Litchi", ImageUrl = "/Images/NotesOlfactives/Litchi.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 26, Nom = "Ananas", ImageUrl = "/Images/NotesOlfactives/Ananas.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 27, Nom = "Mangue", ImageUrl = "/Images/NotesOlfactives/Mangue.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 28, Nom = "Fruit de la passion", ImageUrl = "/Images/NotesOlfactives/Fruit de la passion.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 29, Nom = "Melon", ImageUrl = "/Images/NotesOlfactives/Melon.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 30, Nom = "Pastèque", ImageUrl = "/Images/NotesOlfactives/Pastèque.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 31, Nom = "Noix de coco", ImageUrl = "/Images/NotesOlfactives/Noix de coco.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 32, Nom = "Banane", ImageUrl = "/Images/NotesOlfactives/Banane.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 33, Nom = "Figue", ImageUrl = "/Images/NotesOlfactives/Figue.png", FamilleOlfactiveId = 2 },
    new NoteOlfactive { Id = 34, Nom = "Datte", ImageUrl = "/Images/NotesOlfactives/Datte.png", FamilleOlfactiveId = 2 },

    // =============================
    // FLEURS
    // =============================
    new NoteOlfactive { Id = 35, Nom = "Rose", ImageUrl = "/Images/NotesOlfactives/Rose.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 36, Nom = "Rose bulgare", ImageUrl = "/Images/NotesOlfactives/Rose bulgare.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 37, Nom = "Rose de Mai", ImageUrl = "/Images/NotesOlfactives/Rose de Mai.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 38, Nom = "Jasmin", ImageUrl = "/Images/NotesOlfactives/Jasmin.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 39, Nom = "Jasmin sambac", ImageUrl = "/Images/NotesOlfactives/Jasmin sambac.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 40, Nom = "Tubéreuse", ImageUrl = "/Images/NotesOlfactives/Tubéreuse.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 41, Nom = "Ylang-Ylang", ImageUrl = "/Images/NotesOlfactives/Ylang-Ylang.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 42, Nom = "Gardénia", ImageUrl = "/Images/NotesOlfactives/Gardénia.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 43, Nom = "Fleur d'oranger", ImageUrl = "/Images/NotesOlfactives/Fleur d'oranger.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 44, Nom = "Muguet", ImageUrl = "/Images/NotesOlfactives/Muguet.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 45, Nom = "Pivoine", ImageUrl = "/Images/NotesOlfactives/Pivoine.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 46, Nom = "Magnolia", ImageUrl = "/Images/NotesOlfactives/Magnolia.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 47, Nom = "Iris", ImageUrl = "/Images/NotesOlfactives/Iris.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 48, Nom = "Violette", ImageUrl = "/Images/NotesOlfactives/Violette.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 49, Nom = "Freesia", ImageUrl = "/Images/NotesOlfactives/Freesia.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 50, Nom = "Œillet", ImageUrl = "/Images/NotesOlfactives/Œillet.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 51, Nom = "Héliotrope", ImageUrl = "/Images/NotesOlfactives/Héliotrope.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 52, Nom = "Mimosa", ImageUrl = "/Images/NotesOlfactives/Mimosa.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 53, Nom = "Lilas", ImageUrl = "/Images/NotesOlfactives/Lilas.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 54, Nom = "Lotus", ImageUrl = "/Images/NotesOlfactives/Lotus.png", FamilleOlfactiveId = 3 },
    new NoteOlfactive { Id = 55, Nom = "Narcisse", ImageUrl = "/Images/NotesOlfactives/Narcisse.png", FamilleOlfactiveId = 3 },

    // =============================
    // ÉPICES
    // =============================
    new NoteOlfactive { Id = 56, Nom = "Poivre noir", ImageUrl = "/Images/NotesOlfactives/Poivre noir.png", FamilleOlfactiveId = 4 },
    new NoteOlfactive { Id = 57, Nom = "Poivre rose", ImageUrl = "/Images/NotesOlfactives/Poivre rose.png", FamilleOlfactiveId = 4 },
    new NoteOlfactive { Id = 58, Nom = "Cardamome", ImageUrl = "/Images/NotesOlfactives/Cardamome.png", FamilleOlfactiveId = 4 },
    new NoteOlfactive { Id = 59, Nom = "Cannelle", ImageUrl = "/Images/NotesOlfactives/Cannelle.png", FamilleOlfactiveId = 4 },
    new NoteOlfactive { Id = 60, Nom = "Safran", ImageUrl = "/Images/NotesOlfactives/Safran.png", FamilleOlfactiveId = 4 },
    new NoteOlfactive { Id = 61, Nom = "Clou de girofle", ImageUrl = "/Images/NotesOlfactives/Clou de girofle.png", FamilleOlfactiveId = 4 },
    new NoteOlfactive { Id = 62, Nom = "Noix de muscade", ImageUrl = "/Images/NotesOlfactives/Noix de muscade.png", FamilleOlfactiveId = 4 },
    new NoteOlfactive { Id = 63, Nom = "Gingembre", ImageUrl = "/Images/NotesOlfactives/Gingembre.png", FamilleOlfactiveId = 4 },
    new NoteOlfactive { Id = 64, Nom = "Baies roses", ImageUrl = "/Images/NotesOlfactives/Baies roses.png", FamilleOlfactiveId = 4 },
    new NoteOlfactive { Id = 65, Nom = "Cumin", ImageUrl = "/Images/NotesOlfactives/Cumin.png", FamilleOlfactiveId = 4 },
    new NoteOlfactive { Id = 66, Nom = "Anis étoilé", ImageUrl = "/Images/NotesOlfactives/Anis étoilé.png", FamilleOlfactiveId = 4 },

    // =============================
    // HERBES & AROMATIQUES
    // =============================
    new NoteOlfactive { Id = 67, Nom = "Lavande", ImageUrl = "/Images/NotesOlfactives/Lavande.png", FamilleOlfactiveId = 5 },
    new NoteOlfactive { Id = 68, Nom = "Romarin", ImageUrl = "/Images/NotesOlfactives/Romarin.png", FamilleOlfactiveId = 5 },
    new NoteOlfactive { Id = 69, Nom = "Thym", ImageUrl = "/Images/NotesOlfactives/Thym.png", FamilleOlfactiveId = 5 },
    new NoteOlfactive { Id = 70, Nom = "Sauge", ImageUrl = "/Images/NotesOlfactives/Sauge.png", FamilleOlfactiveId = 5 },
    new NoteOlfactive { Id = 71, Nom = "Menthe", ImageUrl = "/Images/NotesOlfactives/Menthe.png", FamilleOlfactiveId = 5 },
    new NoteOlfactive { Id = 72, Nom = "Basilic", ImageUrl = "/Images/NotesOlfactives/Basilic.png", FamilleOlfactiveId = 5 },
    new NoteOlfactive { Id = 73, Nom = "Estragon", ImageUrl = "/Images/NotesOlfactives/Estragon.png", FamilleOlfactiveId = 5 },
    new NoteOlfactive { Id = 74, Nom = "Absinthe", ImageUrl = "/Images/NotesOlfactives/Absinthe.png", FamilleOlfactiveId = 5 },

    // =============================
    // BOIS
    // =============================
    new NoteOlfactive { Id = 75, Nom = "Bois de santal", ImageUrl = "/Images/NotesOlfactives/Bois de santal.png", FamilleOlfactiveId = 6 },
    new NoteOlfactive { Id = 76, Nom = "Cèdre de Virginie", ImageUrl = "/Images/NotesOlfactives/Cèdre de Virginie.png", FamilleOlfactiveId = 6 },
    new NoteOlfactive { Id = 77, Nom = "Cèdre Atlas", ImageUrl = "/Images/NotesOlfactives/Cèdre Atlas.png", FamilleOlfactiveId = 6 },
    new NoteOlfactive { Id = 78, Nom = "Bois de gaïac", ImageUrl = "/Images/NotesOlfactives/Bois de gaïac.png", FamilleOlfactiveId = 6 },
    new NoteOlfactive { Id = 79, Nom = "Vétiver", ImageUrl = "/Images/NotesOlfactives/Vétiver.png", FamilleOlfactiveId = 6 },
    new NoteOlfactive { Id = 80, Nom = "Patchouli", ImageUrl = "/Images/NotesOlfactives/Patchouli.png", FamilleOlfactiveId = 6 },
    new NoteOlfactive { Id = 81, Nom = "Oud", ImageUrl = "/Images/NotesOlfactives/Oud.png", FamilleOlfactiveId = 6 },
    new NoteOlfactive { Id = 82, Nom = "Cyprès", ImageUrl = "/Images/NotesOlfactives/Cyprès.png", FamilleOlfactiveId = 6 },
    new NoteOlfactive { Id = 83, Nom = "Pin", ImageUrl = "/Images/NotesOlfactives/Pin.png", FamilleOlfactiveId = 6 },
    new NoteOlfactive { Id = 84, Nom = "Cachemire", ImageUrl = "/Images/NotesOlfactives/Cachemire.png", FamilleOlfactiveId = 6 },

    // =============================
    // RÉSINES
    // =============================
    new NoteOlfactive { Id = 85, Nom = "Ambre", ImageUrl = "/Images/NotesOlfactives/Ambre.png", FamilleOlfactiveId = 7 },
    new NoteOlfactive { Id = 86, Nom = "Benjoin", ImageUrl = "/Images/NotesOlfactives/Benjoin.png", FamilleOlfactiveId = 7 },
    new NoteOlfactive { Id = 87, Nom = "Encens", ImageUrl = "/Images/NotesOlfactives/Encens.png", FamilleOlfactiveId = 7 },
    new NoteOlfactive { Id = 88, Nom = "Myrrhe", ImageUrl = "/Images/NotesOlfactives/Myrrhe.png", FamilleOlfactiveId = 7 },
    new NoteOlfactive { Id = 89, Nom = "Labdanum", ImageUrl = "/Images/NotesOlfactives/Labdanum.png", FamilleOlfactiveId = 7 },
    new NoteOlfactive { Id = 90, Nom = "Opoponax", ImageUrl = "/Images/NotesOlfactives/Opoponax.png", FamilleOlfactiveId = 7 },
    new NoteOlfactive { Id = 91, Nom = "Baume du Pérou", ImageUrl = "/Images/NotesOlfactives/Baume du Pérou.png", FamilleOlfactiveId = 7 },

    // =============================
    // GOURMANDES
    // =============================
    new NoteOlfactive { Id = 92, Nom = "Vanille", ImageUrl = "/Images/NotesOlfactives/Vanille.png", FamilleOlfactiveId = 8 },
    new NoteOlfactive { Id = 93, Nom = "Fève Tonka", ImageUrl = "/Images/NotesOlfactives/Fève Tonka.png", FamilleOlfactiveId = 8 },
    new NoteOlfactive { Id = 94, Nom = "Caramel", ImageUrl = "/Images/NotesOlfactives/Caramel.png", FamilleOlfactiveId = 8 },
    new NoteOlfactive { Id = 95, Nom = "Praliné", ImageUrl = "/Images/NotesOlfactives/Praliné.png", FamilleOlfactiveId = 8 },
    new NoteOlfactive { Id = 96, Nom = "Chocolat", ImageUrl = "/Images/NotesOlfactives/Chocolat.png", FamilleOlfactiveId = 8 },
    new NoteOlfactive { Id = 97, Nom = "Cacao", ImageUrl = "/Images/NotesOlfactives/Cacao.png", FamilleOlfactiveId = 8 },
    new NoteOlfactive { Id = 98, Nom = "Miel", ImageUrl = "/Images/NotesOlfactives/Miel.png", FamilleOlfactiveId = 8 },
    new NoteOlfactive { Id = 99, Nom = "Sucre", ImageUrl = "/Images/NotesOlfactives/Sucre.png", FamilleOlfactiveId = 8 },
    new NoteOlfactive { Id = 100, Nom = "Guimauve", ImageUrl = "/Images/NotesOlfactives/Guimauve.png", FamilleOlfactiveId = 8 },
    new NoteOlfactive { Id = 101, Nom = "Amande", ImageUrl = "/Images/NotesOlfactives/Amande.png", FamilleOlfactiveId = 8 },
    new NoteOlfactive { Id = 102, Nom = "Noisette", ImageUrl = "/Images/NotesOlfactives/Noisette.png", FamilleOlfactiveId = 8 },
    new NoteOlfactive { Id = 103, Nom = "Café", ImageUrl = "/Images/NotesOlfactives/Café.png", FamilleOlfactiveId = 8 },
    new NoteOlfactive { Id = 104, Nom = "Lait", ImageUrl = "/Images/NotesOlfactives/Lait.png", FamilleOlfactiveId = 8 },

    // =============================
    // MUSCS & AMBRÉS
    // =============================
    new NoteOlfactive { Id = 105, Nom = "Musc blanc", ImageUrl = "/Images/NotesOlfactives/Musc blanc.png", FamilleOlfactiveId = 9 },
    new NoteOlfactive { Id = 106, Nom = "Ambroxan", ImageUrl = "/Images/NotesOlfactives/Ambroxan.png", FamilleOlfactiveId = 9 },
    new NoteOlfactive { Id = 107, Nom = "Musc", ImageUrl = "/Images/NotesOlfactives/Musc.png", FamilleOlfactiveId = 9 },
    new NoteOlfactive { Id = 108, Nom = "Cashmeran", ImageUrl = "/Images/NotesOlfactives/Cashmeran.png", FamilleOlfactiveId = 9 },
    new NoteOlfactive { Id = 109, Nom = "Iso E Super", ImageUrl = "/Images/NotesOlfactives/Iso E Super.png", FamilleOlfactiveId = 9 },
    new NoteOlfactive { Id = 110, Nom = "Civette", ImageUrl = "/Images/NotesOlfactives/Civette.png", FamilleOlfactiveId = 9 },

    // =============================
    // NOTES MARINES
    // =============================
    new NoteOlfactive { Id = 111, Nom = "Notes marines", ImageUrl = "/Images/NotesOlfactives/Notes marines.png", FamilleOlfactiveId = 10 },
    new NoteOlfactive { Id = 112, Nom = "Sel marin", ImageUrl = "/Images/NotesOlfactives/Sel marin.png", FamilleOlfactiveId = 10 },
    new NoteOlfactive { Id = 113, Nom = "Algues", ImageUrl = "/Images/NotesOlfactives/Algues.png", FamilleOlfactiveId = 10 },

    // =============================
    // NOTES VERTES
    // =============================
    new NoteOlfactive { Id = 114, Nom = "Herbe coupée", ImageUrl = "/Images/NotesOlfactives/Herbe coupée.png", FamilleOlfactiveId = 11 },
    new NoteOlfactive { Id = 115, Nom = "Feuille de violette", ImageUrl = "/Images/NotesOlfactives/Feuille de violette.png", FamilleOlfactiveId = 11 },
    new NoteOlfactive { Id = 116, Nom = "Feuille de tomate", ImageUrl = "/Images/NotesOlfactives/Feuille de tomate.png", FamilleOlfactiveId = 11 },
    new NoteOlfactive { Id = 117, Nom = "Thé vert", ImageUrl = "/Images/NotesOlfactives/Thé vert.png", FamilleOlfactiveId = 11 },
    new NoteOlfactive { Id = 118, Nom = "Maté", ImageUrl = "/Images/NotesOlfactives/Maté.png", FamilleOlfactiveId = 11 },

    // =============================
    // CUIR & TABAC
    // =============================
    new NoteOlfactive { Id = 119, Nom = "Cuir", ImageUrl = "/Images/NotesOlfactives/Cuir.png", FamilleOlfactiveId = 12 },
    new NoteOlfactive { Id = 120, Nom = "Tabac", ImageUrl = "/Images/NotesOlfactives/Tabac.png", FamilleOlfactiveId = 12 },
    new NoteOlfactive { Id = 121, Nom = "Fumée", ImageUrl = "/Images/NotesOlfactives/Fumée.png", FamilleOlfactiveId = 12 },
    new NoteOlfactive { Id = 122, Nom = "Whisky", ImageUrl = "/Images/NotesOlfactives/Whisky.png", FamilleOlfactiveId = 12 },
    new NoteOlfactive { Id = 123, Nom = "Rhum", ImageUrl = "/Images/NotesOlfactives/Rhum.png", FamilleOlfactiveId = 12 },
    new NoteOlfactive { Id = 124, Nom = "Cognac", ImageUrl = "/Images/NotesOlfactives/Cognac.png", FamilleOlfactiveId = 12 }
);
        }
    }
}