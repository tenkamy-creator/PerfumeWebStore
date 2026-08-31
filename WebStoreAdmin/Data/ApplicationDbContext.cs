using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Client> Clients { get; set; } = default!;
        public DbSet<Employe> Employes { get; set; } = default!;
        public DbSet<Parfum> Parfums { get; set; } = default!;
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<LignePanier> LignesPanier { get; set; } = default!;
        public DbSet<ImageParfum> ImagesParfum { get; set; }
        public DbSet<Commande> Commandes { get; set; } = default!;
        public DbSet<LigneCommande> LignesCommande { get; set; }
        public DbSet<Categorie> Categories { get; set; } = default!;
        public DbSet<AdresseLivraison> AdressesLivraison { get; set; } = default!;
        public DbSet<Avis> Avis { get; set; } = default!;
        public DbSet<ArticleCommande> ArticlesCommande { get; set; } = default!;
        public DbSet<Wishlist> Wishlists { get; set; } = default!;
        public DbSet<Paiement> Paiements { get; set; } = default!;
        public DbSet<NoteOlfactive> NotesOlfactives { get; set; } = default!;
        public DbSet<FamilleOlfactive> FamillesOlfactives { get; set; } = default!;
        public DbSet<ParfumNote> ParfumNotes { get; set; } = default!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employe>()
                .HasOne(e => e.ApplicationUser)
                .WithOne()
                .HasForeignKey<Employe>(e => e.UserId);

            builder.Entity<Client>()
                .HasOne(e => e.ApplicationUser)
                .WithOne()
                .HasForeignKey<Client>(e => e.UserId);

            builder.Entity<LignePanier>()
                .HasOne(lp => lp.Panier)
                .WithMany(p => p.Lignes)
                .HasForeignKey(lp => lp.PanierId);

            builder.Entity<LigneCommande>()
                .HasOne(lc => lc.Commande)
                .WithMany(c => c.Lignes)
                .HasForeignKey(lc => lc.CommandeId);

            builder.Entity<ImageParfum>()
                .HasOne(i => i.Parfum)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.ParfumId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ParfumNote>()
                .HasOne(pn => pn.Parfum)
                .WithMany(p => p.Notes)
                .HasForeignKey(pn => pn.ParfumId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ParfumNote>()
                .HasOne(pn => pn.NoteOlfactive)
                .WithMany(n => n.ParfumNotes)
                .HasForeignKey(pn => pn.NoteOlfactiveId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ApplyConfiguration(new CategorieConfiguration());
            builder.ApplyConfiguration(new NoteOlfactiveConfiguration());
            builder.ApplyConfiguration(new FamilleOlfactiveConfiguration());
        }
    }
}
