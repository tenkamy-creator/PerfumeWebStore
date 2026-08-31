using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.Data
{
    public class CategorieConfiguration : IEntityTypeConfiguration<Categorie>
    {
        public void Configure(EntityTypeBuilder<Categorie> builder)
        {
            builder.ToTable("Categorie", schema: "dbo");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nom)
               .HasColumnName("Nom")
               .HasColumnType("nvarchar(100)")
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(c => c.Description)
               .HasColumnName("Description")
               .HasColumnType("nvarchar(max)")
               .IsRequired();

            builder.HasMany(c => c.Parfums)
               .WithOne(p => p.Categorie)
               .HasForeignKey(p => p.CategorieId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Categorie
                {
                    Id = 1,
                    Nom = "Floral",
                    Description = ""
                },
                new Categorie
                {
                    Id = 2,
                    Nom = "Woody",
                    Description = ""
                },
                new Categorie
                {
                    Id = 3,
                    Nom = "Oriental",
                    Description = ""
                },
                new Categorie
                {
                    Id = 4,
                    Nom = "Fresh",
                    Description = ""
                }
                );
        }
    }
}
