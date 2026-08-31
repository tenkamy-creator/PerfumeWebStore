using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.Data
{
    public class FamilleOlfactiveConfiguration : IEntityTypeConfiguration<FamilleOlfactive>
    {
        public void Configure(EntityTypeBuilder<FamilleOlfactive> builder)
        {
            builder.ToTable("FamilleOlfactive", schema: "dbo");

            builder.HasKey(f => f.Id);

            builder.HasData(
                new FamilleOlfactive { Id = 1, Nom = "Agrumes", ImageUrl = "/Images/FamillesOlfactives/Agrumes.png" },
                new FamilleOlfactive { Id = 2, Nom = "Fruitée", ImageUrl = "/Images/FamillesOlfactives/Fruitée.png" },
                new FamilleOlfactive { Id = 3, Nom = "Florale", ImageUrl = "/Images/FamillesOlfactives/Florale.png" },
                new FamilleOlfactive { Id = 4, Nom = "Épicée", ImageUrl = "/Images/FamillesOlfactives/Épicée.png" },
                new FamilleOlfactive { Id = 5, Nom = "Aromatique", ImageUrl = "/Images/FamillesOlfactives/Aromatique.png" },
                new FamilleOlfactive { Id = 6, Nom = "Boisée", ImageUrl = "/Images/FamillesOlfactives/Boisée.png" },
                new FamilleOlfactive { Id = 7, Nom = "Orientale", ImageUrl = "/Images/FamillesOlfactives/Orientale.png" },
                new FamilleOlfactive { Id = 8, Nom = "Gourmande", ImageUrl = "/Images/FamillesOlfactives/Gourmande.png" },
                new FamilleOlfactive { Id = 9, Nom = "Fixateur synthétique", ImageUrl = "/Images/FamillesOlfactives/Fixateur synthétique.png" },
                new FamilleOlfactive { Id = 10, Nom = "Aquatique", ImageUrl = "/Images/FamillesOlfactives/Aquatique.png" },
                new FamilleOlfactive { Id = 11, Nom = "Verte", ImageUrl = "/Images/FamillesOlfactives/Verte.png" },
                new FamilleOlfactive { Id = 12, Nom = "Cuirée", ImageUrl = "/Images/FamillesOlfactives/Cuirée.png" },
                new FamilleOlfactive { Id = 13, Nom = "Fougère", ImageUrl = "/Images/FamillesOlfactives/Fougère.png" },
                new FamilleOlfactive { Id = 14, Nom = "Chyprée", ImageUrl = "/Images/FamillesOlfactives/Chyprée.png" }
            );
        }
    }
}